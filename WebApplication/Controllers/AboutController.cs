using Microsoft.AspNetCore.Mvc;

namespace Keyify.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
