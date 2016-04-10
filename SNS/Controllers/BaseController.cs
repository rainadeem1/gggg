using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNS.Models;
using SNS.DAL;
namespace SNS.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base

        public bool Authentication() {
            bool result = false;
            if (Session[Shared.Current_Student]!=null)
            {
                var student = Session[Shared.Current_Student] as sp_StudentMail_Result;
                ViewBag.type = student.personType;
                ViewBag.personID = student.StudentID;
                ViewBag.fname = student.FirstName;
                ViewBag.lanme = student.LastName;
                ViewBag.picture = student.Picture;
                result = true;
            }
            if (Session[Shared.Current_Faculity] != null)
            {
                var Faculity = Session[Shared.Current_Faculity] as sp_FacultyMail_Result;
                ViewBag.type =Faculity.personType;
                ViewBag.FaculityID = Faculity.FacultyId;
                ViewBag.personID = Faculity.personId;
                ViewBag.fname = Faculity.FirstName;
                ViewBag.lanme = Faculity.LastName;
                ViewBag.picture = Faculity.Picture;
                result = true;
            }

            return result;
        }

        public string Uploads()
        {
            string path = null;
            if (Request.Files != null && Request.Files.Count > 0)
            {
                int counter = 0;
                foreach (string f in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[f];
                    if (file.FileName == "")
                    {
                       path = "/Pictures/default.jpg";
                    }
                    else
                    {
                        string webpath = "/Pictures/" + DateTime.Now.Ticks + "_" + ++counter + file.FileName.Substring(file.FileName.LastIndexOf("."));
                        file.SaveAs(Request.MapPath(webpath)); //physical path is required to save a file
                        path = webpath;
                    }
                }
            }
            return path;
        }

        public string UploadFile()
        {
            string path = null;
            if (Request.Files != null && Request.Files.Count > 0)
            {
                int counter = 0;
                foreach (string f in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[f];
                    if (file.FileName == "")
                    {
                        path = "/Files/defaultFile.png";
                    }
                    else
                    {
                        string webpath = "/Files/" + DateTime.Now.Ticks + "_" + ++counter + file.FileName.Substring(file.FileName.LastIndexOf("."));
                        file.SaveAs(Request.MapPath(webpath)); //physical path is required to save a file
                        path = webpath;
                    }
                }
            }
            return path;
        }
    }
}