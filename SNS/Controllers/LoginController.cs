using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNS.Models;
using SNS.DAL;
namespace SNS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection dt)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {

                string email = dt["Email"];
                string pass = dt["Password"];
                string type = dt["Type"];
                if (type== "Student")
                {
                     var data = db.sp_StudentMail(email).FirstOrDefault();
                    if (data != null)
                    {
                        if (data.Password != pass)
                        {
                            Shared.Message = "Please enter correct password";
                            return View("Index");
                        }
                        else
                        {
                            Session[Shared.Current_Student] = data;
                           
                            return RedirectToAction("index","home");
                        }
                    }
                    else
                    {
                        Shared.Message = "User Not Found";
                        return View("Index");
                    }
                }
                if (type == "Faculity")
                {
                    var data = db.sp_FacultyMail(email).FirstOrDefault();
                    if (data != null)
                    {
                        if (data.Password != pass)
                        {
                            Shared.Message = "Please enter correct password";
                            return View("Index");
                        }
                        else
                        {
                            Session[Shared.Current_Faculity] = data;

                            return RedirectToAction("index", "home");
                        }
                    }
                    else
                    {
                        Shared.Message = "User Not Found";
                        return View("Index");
                    }
                }

               
                return null;
            }

        }

        public ActionResult logout() {
            Session[Shared.Current_Faculity] = null;
            Session[Shared.Current_Student] = null;
            return RedirectToAction("index");
        }
    }
}