using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class StudentCourseHandler
    {
        public static void Save(CourseMetarialEntities db,StudentCours sc) {
            sc.Approval = false;
            db.StudentCourses.Add(sc);
            db.SaveChanges();
        }
        public static List<StudentCours> All(CourseMetarialEntities db)
        {
            return db.StudentCourses.ToList();
        }

        public static List<StudentCours> CourseID(CourseMetarialEntities db,int courseID)
        {
            return db.StudentCourses.Where(m => m.CourseID == courseID).ToList();
        }

        public static List<sp_UnApproveStudentCourses_Result> UnApproveCourses(int TeacherID)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.sp_UnApproveStudentCourses(TeacherID).ToList();
            }

        }

        public static List<StudentCours> studentID(CourseMetarialEntities db, int id)
        {
            return db.StudentCourses.Where(m => m.StudetentID == id).ToList();
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

        public static string Delete( int id)
        {
            using (CourseMetarialEntities db=new CourseMetarialEntities()) {
                var dt= db.StudentCourses.Where(m => m.Id == id).FirstOrDefault();
                if (dt!=null)
                {
                    db.StudentCourses.Remove(dt);
                    db.SaveChanges();
                    return "deleted";
                }
                return "not delete";
            }
                
        }

        public static void UpdateApproval(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt = db.StudentCourses.Where(m => m.Id == id).FirstOrDefault();
                if (dt != null)
                {
                    dt.Approval = true;
                    db.SaveChanges();
                }
            }

        }
    }
}