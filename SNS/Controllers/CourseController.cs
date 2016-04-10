using SNS.DAL;
using SNS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SNS.Controllers
{
    public class CourseController : BaseController
    {
        // GET: Designation
        public ActionResult New(int id = 0)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            return View(CourseHandler.ID(id));
        }

        [HttpPost]
        public ActionResult Save(Cours des)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            if (des.Id > 0)
            {
                CourseHandler.Update(des.Id, des);
            }
            else
            {
                var dt = CourseHandler.Code(des.Code);
                if (dt!=null)
                {
                    Shared.Message = "This code already exist";
                    return View("New");
                }
                else
                {
                    CourseHandler.Save(des);
                }
               
            }

            return RedirectToAction("all");
        }

        public ActionResult All()
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            return View(CourseHandler.All());
        }
        public ActionResult Delete(int id)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            CourseHandler.Delete(id);
            return RedirectToAction("all");
        }

       
    }
}