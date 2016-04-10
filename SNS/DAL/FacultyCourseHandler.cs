using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class FacultyCourseHandler
    {
        public static void Save(CourseMetarialEntities db,TeacherCours sc) {
          
            db.TeacherCourses.Add(sc);
            db.SaveChanges();
        }

        public static void Delete( int id)
        {
            using (CourseMetarialEntities db=new CourseMetarialEntities()) {
                var dt= db.TeacherCourses.Where(m => m.Id == id).FirstOrDefault();
                if (dt!=null)
                {
                    db.TeacherCourses.Remove(dt);
                    db.SaveChanges();
                }
            }
                
        }
    }
}