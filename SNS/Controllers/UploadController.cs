using SNS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNS.Models;
namespace SNS.Controllers
{
    public class UploadController : BaseController
    {
        // GET: Upload
        public ActionResult New()
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            if (ViewBag.type=="Admin")
            {
                ViewBag.courses = Dropdown.Courses();
            }
            else
            {
                ViewBag.courses = Dropdown.TeacherCourses(ViewBag.FaculityID);
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Save(Upload up)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            using (CourseMetarialEntities db=new CourseMetarialEntities()) {
                using (var trans=db.Database.BeginTransaction()) {
                    try
                    {
                        up.FilePath = UploadFile();
                        up.FileType= up.FilePath.Substring(up.FilePath.LastIndexOf("."));
                        up.FacultyID = ViewBag.FaculityID;
                        int UploadID=  UploadsHandler.Save(db,up);
                        StudentCourseHandler.NotityUploadFile(db,(int)up.CourseID, UploadID);
                        trans.Commit();
                        foreach (var std in PersonHandler.Type("Student"))
                        {
                            MobileHandler.Send_sms(std.Phone,up.FileName+ " Uploaded");
                        }
                        Shared.Message = "Notes Uploaded";
                    }
                    catch (Exception ex) { Shared.Message = "Some Error like "+ex.Message; trans.Rollback(); }
                }
            }
                return RedirectToAction("all");
        }

        public ActionResult All()
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            return View(UploadsHandler.All());
        }

        public ActionResult Details(int id=0)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            return View(UploadsHandler.ID(id));
        }

        public ActionResult delete(int id = 0)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            UploadsHandler.Delete(id);
            return RedirectToAction("all");
        }

        public ActionResult Comments(int id = 0)
        {
              if (!Authentication()) { return RedirectToAction("index", "login"); }
            return PartialView("~/views/upload/_comments.cshtml",UploadCommentHandler.UploadId(id));
        }
    }
}