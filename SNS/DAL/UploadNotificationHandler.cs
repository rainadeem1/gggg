using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
namespace SNS.DAL
{
    public class UploadNotificationHandler
    {
        public static void Save(CourseMetarialEntities db,UploadNotification up) {
            db.UploadNotifications.Add(up);
            db.SaveChanges();
        }
    }
}