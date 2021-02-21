using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Keyify.Controllers
{
    public class VersionController : Controller
    {
        [HttpGet]        
        public ActionResult Index()
        {
            return Ok(Assembly.GetEntryAssembly().GetName().Version);
        }
    }
}
