using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNS.Models;
using SNS.DAL;
namespace SNS.Controllers
{
    public class FacultyController : BaseController
    {
        public ActionResult New(int id = 0,string title=null)
        {
         //   if (!Authentication()) { return RedirectToAction("index", "login"); }
            ViewBag.FacultyTitle = title;
            ViewBag.Des = Dropdown.Designations();
            return PartialView("~/views/faculty/_new.cshtml", FacultyHandler.ID(id));
        }
    }
}