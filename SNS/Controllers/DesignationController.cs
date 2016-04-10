using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNS.Models;
using SNS.DAL;
namespace SNS.Controllers
{
    public class DesignationController : BaseController
    {
        // GET: Designation
        public ActionResult New(int id=0)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            return View(DesignationHandler.ID(id));
        }

        [HttpPost]
        public ActionResult Save(Designation des)
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            if (des.Id>0)
            {
                DesignationHandler.Update(des.Id,des);
            }
            else
            {
                DesignationHandler.Save(des);
            }
            
            return RedirectToAction("all");
        }

        public ActionResult All()
        {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            return View(DesignationHandler.All());
        }
        public ActionResult Delete(int id) {
            if (!Authentication()) { return RedirectToAction("index", "login"); }
            DesignationHandler.Delete(id);
            return RedirectToAction("all");
        }
    }
}