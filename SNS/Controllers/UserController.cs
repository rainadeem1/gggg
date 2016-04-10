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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult New(int id=0,string title=null)
        {
            ViewBag.UserTitle = title;
            return PartialView("~/views/user/_new.cshtml",UserHandler.ID(id));
        }

        public string Email(string email)
        {

            var dt = UserHandler.Email(email);
            return JsonConvert.SerializeObject(dt);
          
            //   return Json(dt, JsonRequestBehavior.AllowGet); 
        }
    }
}