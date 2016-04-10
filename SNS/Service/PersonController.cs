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
    public class PersonController : ApiController
    {
        // GET: api/Person
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Person/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Person
        public string Post(string name)
        {
            return name;
        }

        //public string Post([FromBody]Person p)
        //{
        //    try
        //    {
        //        using (CourseMetarialEntities db = new CourseMetarialEntities())
        //        {
        //            PersonHandler.Save(db, p);
        //            return "Successful";
        //        }

        //    }
        //    catch (Exception ex) { return "Error +"+ex.Message; }

        //}

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
