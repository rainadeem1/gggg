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
    public class TeacherController : BaseController
    {
        // GET: Teacher
        public ActionResult Index()
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            FacultyTypeHandler.InitializeType("Teacher", 2);
            ViewBag.courses = Dropdown.Courses();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Person p, Faculty f, User u,FormCollection dt)
        {
           // if (!Authentication()) { return RedirectToAction("index", "login"); }
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var email = UserHandler.Email(u.Email);
                        if (email != null)
                        {
                            Shared.Message = "This email already exist";
                            return View("Index");
                        }
                        p.Picture = Uploads();
                        u.Type = "Teacher";
                        p.PersonType = "Teacher";
                        int perID = PersonHandler.Save(db, p);
                        f.PersonID = perID;
                       

                        u.PersonID = perID;
                        UserHandler.Save(db, u);

                        f.TypeID = FacultyTypeHandler.Title("Teacher").Id;
                     int fID=   FacultyHandler.Save(db, f);


                        string[] courses = dt["courses"].Split(',');
                        for (int i = 0; i < courses.Length; i++)
                        {
                            TeacherCours tc = new TeacherCours();
                           tc.FacultyID = fID;
                            tc.CourseID = Convert.ToInt32(courses[i]);
                            FacultyCourseHandler.Save(db, tc);
                        }

                        trans.Commit();
                        Shared.Message = p.FirstName + " Save";
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Shared.Message = "Some Error Like " + ex.Message;
                        Redirect("~/Teacher/index");
                    }
                }
            }
            return RedirectToAction("all");
        }

        public ActionResult All()
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            return View(FacultyHandler.FacultyTitle("Teacher"));
        }


        public ActionResult Courses()
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            ViewBag.courses = Dropdown.Courses();
            return View();
        }
        public ActionResult SaveCourses(TeacherCours tc)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            using (CourseMetarialEntities db=new CourseMetarialEntities()) {
                TeacherCourseHandler.Save(db,tc);
            }
               
            return RedirectToAction("CoursesAll");
        }

        public ActionResult CoursesAll()
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
           
            return View(TeacherCourseHandler.TeacherCourses(ViewBag.FaculityID));
        }
        public ActionResult CoursesDel(int id)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            TeacherCourseHandler.Delete(id);
            return RedirectToAction("CoursesAll");
        }

        public ActionResult Delete(int id)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            PersonHandler.Delete(id);
            Shared.Message = "Teacher Deleted";
            return RedirectToAction("All");
        }

        public string UnApproveStudentCourses(int TeacherID)
        {
           // if (!Authentication()) { return null; }

            var dt = StudentCourseHandler.UnApproveCourses(TeacherID);
                return JsonConvert.SerializeObject(dt);
        }
    }
}