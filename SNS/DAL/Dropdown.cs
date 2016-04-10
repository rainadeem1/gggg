using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
using SNS.DAL;
using System.Web.Mvc;

namespace SNS.DAL
{
    public class Dropdown
    {
        public static List<SelectListItem> Designations()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var lst = DesignationHandler.All();
            if (lst != null)
            {

                items.Add(new SelectListItem { Text = "Select Designation", Value = "" });
                foreach (var item in lst)
                {
                    items.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }
            }

            return items;
        }

        public static List<SelectListItem> Courses()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var lst = CourseHandler.All();
            if (lst != null)
            {

            //    items.Add(new SelectListItem { Text = "Select Designation", Value = "" });
                foreach (var item in lst)
                {
                    items.Add(new SelectListItem { Text = item.Name+" "+item.Code, Value = item.Id.ToString() });
                }
            }

            return items;
        }

        public static List<SelectListItem> TeacherCourses(int id)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var lst = TeacherCourseHandler.TeacherCourses(id);
            if (lst != null)
            {

                //    items.Add(new SelectListItem { Text = "Select Designation", Value = "" });
                foreach (var item in lst)
                {
                    items.Add(new SelectListItem { Text = item.Name + " " + item.Code, Value = item.courseID.ToString() });
                }
            }

            return items;
        }
    }
}