using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class UploadsHandler
    {
        public static int Save(CourseMetarialEntities db,Upload up) {
                up.Timee = DateTime.Now;
                db.Uploads.Add(up);
                db.SaveChanges();
            return up.Id;
        }
        public static List<Upload> All()
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return (from a in db.Uploads
                        orderby a.Timee descending
                        select a).ToList();
              

            }
        }
        public static List<Upload> CourseID(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Uploads.Where(m=>m.CourseID==id).ToList();

            }
        }
        public static List<Upload> FacultyID(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Uploads.Where(m => m.FacultyID == id).ToList();

            }
        }
        public static Upload ID(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.Uploads.Where(m => m.Id == id).FirstOrDefault();

            }
        }
        public static void Delete(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt= db.Uploads.Where(m => m.Id == id).FirstOrDefault();
                if (dt!=null)
                {
                    db.Uploads.Remove(dt);
                    db.SaveChanges();
                    Shared.Message =dt.FileName+ " Deleted";
                }


            }
        }

        public static string FileExtension(string ext) {
            if (ext == ".docx" || ext==".DOCX")
            {
                return "/Files/docx.png";
            }
            if (ext == ".png" || ext== ".PNG")
            {
                return "/Files/png.png";
            }
            if (ext == ".pdf" || ext == ".PDF")
            {
                return "/Files/pdf.png";
            }
            return "/Files/defaultFile.png"; ;

        }

    }
}