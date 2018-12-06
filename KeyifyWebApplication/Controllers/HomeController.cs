using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KeyifyWebApplication.Controllers
{
    public class HomeController : ApiController
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Message { get; set; }
        }

        [HttpGet]
        public IHttpActionResult TestPersonModel([FromBody] Person person)
        {
            try
            {
                person.Message = "Message property set on the TestPersonModel ApiController Method";

                return Ok(person);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
