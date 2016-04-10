using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNS.Models;
using SNS.DAL;
namespace SNS.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            FacultyTypeHandler.InitializeType("Admin",1);
            return View();
        }
        [HttpPost]
        public ActionResult Save(Person p,Faculty f,User u)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            using (CourseMetarialEntities db=new CourseMetarialEntities()) {
                using (var trans=db.Database.BeginTransaction()) {
                    try
                    {
                        var email = UserHandler.Email(u.Email);
                        if (email!=null)
                        {
                            Shared.Message = "This email already exist";
                            return View("Index");
                        }
                        p.Picture = Uploads();
                        u.Type = "Admin";
                        p.PersonType= "Admin";
                        int perID = PersonHandler.Save(db, p);
                        f.PersonID = perID;

                        u.PersonID = perID;
                        UserHandler.Save(db, u);
                        f.TypeID = FacultyTypeHandler.Title("Admin").Id;
                        FacultyHandler.Save(db, f);

                    //    u.PersonID = perID;
                      
                        trans.Commit();
                        Shared.Message =p.FirstName +" Save";
                    }
                    catch (Exception ex) {
                        trans.Rollback();
                        Shared.Message = "Some Error Like " + ex.Message;
                        Redirect("~/admin/index");
                    }
                }
            }
                return RedirectToAction("all");
        }

        public ActionResult All() {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            return View(FacultyHandler.FacultyTitle("Admin"));
        }
        public ActionResult Details(int id=0)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }

            return View(FacultyHandler.ID(id));
        }
        public ActionResult Delete(int id)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            PersonHandler.Delete(id);
            Shared.Message = "Admin Deleted";
            return RedirectToAction("All");
        }
    }
}