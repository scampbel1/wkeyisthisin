using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Keyify.Controllers
{
    public class HealthCheckController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(Assembly.GetEntryAssembly().GetName().Version);
        }
    }
}
