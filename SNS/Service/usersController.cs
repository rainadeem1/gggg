
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
    public class usersController : ApiController
    {
        // GET: api/users
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //   GET: api/users/5
        [Route("api/login/admin")]
        [HttpGet]
        public sp_FacultyMail_Result Get(string email, string pass)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt = db.sp_FacultyMail(email).FirstOrDefault();
                if (dt != null)
                {
                    if (dt.Password != pass)
                    {
                        return null;
                    }
                    else
                    {
                        return dt;
                    }
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        [Route("api/login/student")]
        [HttpGet]
        public sp_StudentMail_Result Student(string email, string pass)
        {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt = db.sp_StudentMail(email).FirstOrDefault();
                if (dt != null)
                {
                    if (dt.Password != pass)
                    {
                      
                        return null;
                    }
                    else
                    {
                        return dt;
                    }
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        // POST: api/users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/users/5
        public void Delete(int id)
        {
        }
    }
}
