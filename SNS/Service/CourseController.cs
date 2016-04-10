using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SNS.Models;
using SNS.DAL;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Web.Services;
using System.Runtime.Serialization;

namespace SNS.Service
{
    public class CourseController : ApiController
    {
        //  [WebService(Namespace = "")]
      
        [Route("api/all/Course")]
        [HttpGet]
        
        public List<Cours> All()
        {
            return CourseHandler.All();
            
        }

        // GET: api/Course/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Course
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Course/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Course/5
        public void Delete(int id)
        {
        }
    }
}
