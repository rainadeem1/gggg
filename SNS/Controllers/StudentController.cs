using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNS.Models;
using SNS.DAL;
using Newtonsoft.Json;

namespace SNS.Controllers
{
    public class StudentController : BaseController
    {
        // GET: Student
        public ActionResult Index()
        {
          //  if (!Authentication()) { return RedirectToAction("index", "login"); }
            ViewBag.courses = Dropdown.Courses();
            return View();
        }
        public ActionResult New(int id=0)
        {

            return PartialView("/views/student/_new.cshtml");
        }

        [HttpPost]
        public ActionResult Save(Person p, Student s, User u,FormCollection dt)
        {
          //  if (!Authentication()) { return RedirectToAction("index", "login"); }
            ViewBag.courses = Dropdown.Courses();
            var Roll = StudentHandler.RollNo(s.RollNo);
            if (Roll != null)
            {
                Shared.Message = "This Roll number already Registered";
                return View("Index");
            }
            var email = UserHandler.Email(u.Email);
            if (email != null)
            {
                Shared.Message = "This email already exist";
                return View("Index");
            }
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        p.Picture = Uploads();
                        u.Type = "Student";
                        p.PersonType = "Student";
                        int perID = PersonHandler.Save(db, p);
                        s.PersonID = perID;
                

                        u.PersonID = perID;
                     UserHandler.Save(db, u);

                        int stdID = StudentHandler.Save(db, s);

                        string[] courses = dt["courses"].Split(',');
                        for (int i = 0; i < courses.Length; i++)
                        {
                            StudentCours sc = new StudentCours();
                            sc.StudetentID = stdID;
                            sc.CourseID =Convert.ToInt32( courses[i]);
                            StudentCourseHandler.Save(db,sc);
                        }

                        trans.Commit();
                        Shared.Message = p.FirstName + " Save";
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Shared.Message = "Some Error Like " + ex.Message;
                        Redirect("~/admin/index");
                    }
                }
            }
            return RedirectToAction("all");
        }

        public ActionResult All()
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            return View(StudentHandler.All());
        }

        public ActionResult Details(int id=0)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            return View(StudentHandler.ID(id));
        }

       
        public ActionResult CourseApproval(int StudentCourseID,int stdID)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            StudentCourseHandler.UpdateApproval(StudentCourseID);
            return RedirectToAction("Details", new {id= stdID });
        }

        public ActionResult DelStdCourse(int StudentCourseID,int stdID)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            StudentCourseHandler.Delete(StudentCourseID);
            return RedirectToAction("Details", new { id = stdID });
        }

        public ActionResult Delete( int id)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            PersonHandler.Delete(id);
            Shared.Message = "Student Deleted";
            return RedirectToAction("All");
        }



        //JSON


    }
}