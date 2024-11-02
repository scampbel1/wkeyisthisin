using Microsoft.AspNetCore.Mvc;

namespace Keyify.Web.Controllers.Music_Theory
{
    public class MusicTheoryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("/UnderConstruction");
        }
    }
}
