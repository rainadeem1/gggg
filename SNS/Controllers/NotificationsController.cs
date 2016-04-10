using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNS.Controllers
{
    public class NotificationsController : Controller
    {
        // GET: Notifications
        public ActionResult New()
        {
            return View();
        }
    }
}