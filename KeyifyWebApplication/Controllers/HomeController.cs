using System.Web.Http;
using KeyifyWebApplication.Models;

namespace KeyifyWebApplication.Controllers
{
    public class HomeController : ApiController
    {
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
