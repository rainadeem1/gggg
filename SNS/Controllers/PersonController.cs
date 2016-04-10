using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNS.Models;
using SNS.DAL;
namespace SNS.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult New(int id=0)
        {

            return PartialView("~/views/person/_new.cshtml",PersonHandler.ID(id));
        }
    }
}