using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class StudentHandler
    {
        public static int Save(CourseMetarialEntities db,Student std) {

            std.Date = DateTime.Now;
            db.Students.Add(std);
            db.SaveChanges();
            return std.Id;
        }

        public static List<Student> All()
        {
            using (CourseMetarialEntities db=new CourseMetarialEntities()) {
                return (from a in db.Students
                        .Include("Person")
                        select a).ToList();
            }
        }

        public static Student ID(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return (from a in db.Students
                        .Include("Person")
                        where a.Id==id
                        select a).FirstOrDefault();
            }
        }

        public static Student RollNo(string roll)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return (from a in db.Students
                        .Include("Person")
                        where a.RollNo == roll
                        select a).FirstOrDefault();
            }
        }

        public static List<Student> Status()
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return (from a in db.Students
                        .Include("Person")
                        select a).ToList();
            }
        }

        public static void Approval(int id,bool status)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt = db.Students.Where(m => m.Id == id).FirstOrDefault();
                if (dt!=null)
                {
                   // dt.Approval = status;
                    db.SaveChanges();
                }
            }
        }
    }
}