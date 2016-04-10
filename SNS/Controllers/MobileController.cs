using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNS.Models;
using SNS.DAL;

namespace SNS.Controllers
{
    public class MobileController : BaseController
    {
        // GET: Mobile
        public ActionResult Index()
        {
            if (!Authentication()) return RedirectToAction("Index", "Home");
           // ViewBag.AllClasses = Shared.AllClasses();
            return View();
        }
        public ActionResult ChangePort(string port) {
            if (!Authentication()) return RedirectToAction("Index", "Home");

            MobileHandler.UpdatePort(port);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SendMsg(string number,string msg,string To,string classes)
        {
            if (!Authentication()) return RedirectToAction("Index", "Home");

            Shared.Message = null;
            if (To == "std")
            {
                foreach (var std in PersonHandler.Type("Student"))
                {
                    MobileHandler.Send_sms(std.Phone, msg);
                }

            }

            if (To == "tchr")
            {
                foreach (var std in PersonHandler.Type("Teacher"))
                {
                    MobileHandler.Send_sms(std.Phone, msg);
                }
            }
            if (number!=null)
            {
                string[] num = number.Split(',');
                foreach (string item in num)
                {
                    MobileHandler.Send_sms(item, msg);
                }
            }
           
            
            return RedirectToAction("Index");
        }

        public ActionResult newORupdate() {

            return PartialView("~/Views/Mobile/_newMsg.cshtml");
        }

        [HttpPost]
        public ActionResult SaveMessage(Mobile mb)
        {
            if (!Authentication()) return RedirectToAction("Index", "Home");
            try
            {
                MobileHandler.Save(mb);
                Shared.Message = "Message has been saved";
            }
            catch (Exception)
            {

                Shared.Message = "Some Error OR Title may be dublicate";
            }
           
            return RedirectToAction("Index");
        }

        public ActionResult Allmsgs()
        {
            return PartialView("~/Views/Mobile/_allMsgs.cshtml",MobileHandler.AllMessage());
        }

        public ActionResult Delete(int id) {
            MobileHandler.Delete(id);
            return RedirectToAction("index");
        }
    }
}