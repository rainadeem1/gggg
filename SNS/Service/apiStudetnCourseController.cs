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
    public class apiStudetnCourseController : ApiController
    {
       public class listdata{
            public int coursID { get; set; }
            public string courseName { get; set;}
            public int studentCourseID { get; set; }
            public string courseCode { get; set; }
        }
        [Route("api/apistudentCourse/list/{id}")]
        [HttpGet]
        public List<listdata> Get(int id)
        {
            using (CourseMetarialEntities db=new CourseMetarialEntities()) {
                return (from a in db.StudentCourses
                        where a.StudetentID == id
                        select new listdata() {studentCourseID=a.Id, coursID=(int) a.CourseID,courseName=a.Cours.Name, courseCode=a.Cours.Code }).ToList();
            }
        }

        [Route("api/apistudentCourse/Delete/{id}")]
        [HttpGet]

        public string Delete(int id)
        {
           
                try
                {
                return StudentCourseHandler.Delete(id);
                   
                }
                catch (Exception ex) { return "Some error like " + ex.Message; }

           
        }

        [Route("api/apistudentCourse/New")]
        [HttpPost]

        public string New(StudentCours st)
        {
            using (CourseMetarialEntities db=new CourseMetarialEntities())
            {
                try
                {
                    StudentCourseHandler.Save(db, st);
                    return "Saved";
                }
                catch (Exception ex) { return "Some error like "+ex.Message; }
               
            }
        }


        // POST: api/StudetnCourse
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/StudetnCourse/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/StudetnCourse/5
        //public void Delete(int id)
        //{
        //}
    }
}
