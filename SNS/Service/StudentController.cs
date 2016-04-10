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
    public class StudentController : ApiController
    {
        // GET: api/Student
       

        [Route("api/studentNew/PersonInfo")]
        [HttpPost]

        public string New(Person p)
        {
           
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        p.PersonType = "Student";
                        p.Picture = "/Pictures/default.jpg";
                      //  u.Type = "Student";
                        int perID = PersonHandler.Save(db, p);

                        trans.Commit();
                        return perID.ToString();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return "Some Error Like " + ex.Message;

                    }
                }
            }
            
        }


        [Route("api/studentNew/Student")]
        [HttpPost]

        public string Student(Student s)
        {
            //, Student s, User u
            var Roll = StudentHandler.RollNo(s.RollNo);
            if (Roll != null)
            {
                return "This Roll number already Registered";

             }
                using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                     int    stdID = StudentHandler.Save(db, s);
                        trans.Commit();
                        return stdID.ToString();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return "Some Error Like " + ex.Message;

                    }
                }
            }

        }


        [Route("api/studentNew/UserInfo")]
        [HttpPost]

        public string User(User u)
        {

            var email = UserHandler.Email(u.Email);
            if (email != null)
            {
                return "This email already exist";

            }
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        u.Type = "Student";
                   int Uid=     UserHandler.Save(db, u);

                        trans.Commit();
                        return Uid.ToString();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return "Some Error Like " + ex.Message;

                    }
                }
            }
           

        }

    }
}
