using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class TeacherCourseHandler
    {
        public static void Save(CourseMetarialEntities db,TeacherCours sc) {
          
            db.TeacherCourses.Add(sc);
            db.SaveChanges();
        }
        public static List<TeacherCours> All(CourseMetarialEntities db)
        {
            return db.TeacherCourses.ToList();
        }

        public static bool IsTeacherCourse(int CourseID,int TeacherID)
        {
            using (CourseMetarialEntities db=new CourseMetarialEntities()) {

                var dt = db.TeacherCourses.Where(m => m.CourseID == CourseID && m.FacultyID == TeacherID).FirstOrDefault();
                if (dt!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
               
        }

        public static List<sp_teacherCourses_Result> TeacherCourses(int id)
        {
            using (CourseMetarialEntities db=new CourseMetarialEntities()) {
                return db.sp_teacherCourses(id).ToList();
            }
                
        }

        public static List<StudentCours> CourseID(CourseMetarialEntities db,int courseID)
        {
            return db.StudentCourses.Where(m => m.CourseID == courseID).ToList();
        }

        public static void NotityUploadFile(CourseMetarialEntities db,int courseID, int UploadID)
        {
            var dt = CourseID(db, courseID);
            foreach (var item in dt)
            {
                UploadNotification upn = new UploadNotification();
                upn.StudentID = item.StudetentID;
                upn.UploadID = UploadID;
                upn.ReadStatus = true;
                UploadNotificationHandler.Save(db,upn);
            }
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