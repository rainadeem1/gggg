using SNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNS.DAL
{
    public class UploadCommentHandler
    {
        public static int Save(UploadComment up)
        {
            try
            {
                using (CourseMetarialEntities db = new CourseMetarialEntities())
                {

                    db.UploadComments.Add(up);
                    db.SaveChanges();
                    return up.Id;
                }
            }
            catch (Exception ex) {
                Shared.Message = "Some Error Like " + ex.Message;
                return 0;
            }
        }

        public static List<sp_comments_Result> UploadId(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.sp_comments(id).ToList();
            }
        }

        public static UploadComment ID(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.UploadComments.Where(m => m.Id == id).FirstOrDefault();
            }
        }


       

        public static void Delete(int id)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt = db.UploadComments.Where(m => m.Id == id).FirstOrDefault();
                if (dt != null)
                {
                    db.UploadComments.Remove(dt);
                    db.SaveChanges();
                }
            }
        }

       
    }
}