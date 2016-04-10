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
    public class TeacherCoursesController : ApiController
    {
        [Route("api/teacherCourses/{id}")]
        [HttpGet]
        public IEnumerable<sp_teacherCourses_Result> list(int id)
        {
            return TeacherCourseHandler.TeacherCourses(id);
        }

        // GET: api/TeacherCourses/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TeacherCourses
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TeacherCourses/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TeacherCourses/5
        public void Delete(int id)
        {
        }
    }
}
