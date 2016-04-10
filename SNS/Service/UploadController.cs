using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SNS.Models;
using SNS.DAL;
namespace SNS.Service
{
    public class UploadController : ApiController
    {
        [Route("api/Notification/studetnID/{id}")]
        [HttpGet]

        public List<sp_OnUploadNotifications_Result> Notification(int id)
        {
           // int id = 0;
            using (CourseMetarialEntities db=new CourseMetarialEntities()) {
                return db.sp_OnUploadNotifications(id).ToList();
            }
        }

        [Route("api/Notification/CourseID/{id}")]
        [HttpGet]

        public List<sp_OnUploadNotifications_Course_Result> CourseID(int id)
        {
            // int id = 0;
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                return db.sp_OnUploadNotifications_Course(id).ToList();
            }
        }

        [Route("api/Uploads/{id}")]
        [HttpGet]

        public Upload Uploads(int id)
        {
          return   UploadsHandler.ID(id);
        }


        [Route("api/Comments/New")]
        [HttpPost]

        public string comment(UploadComment up)
        {
         int id=   UploadCommentHandler.Save(up);
          return id.ToString();
        }

        [Route("api/Comments/{id}")]
        [HttpGet]

        public List<sp_comments_Result> byId(int id)
        {
            return UploadCommentHandler.UploadId(id);
        }

    }
}
