using Microsoft.AspNetCore.Mvc;

namespace Keyify.Web.Controllers.Quicklink
{
    public class QuickLinkController : Controller
    {
        [HttpGet("/{code}")]
        public IActionResult Index(string code)
        {
            //TODO: Do not merge until this is completed

            return RedirectToAction("Index", "Guitar");
        }
    }
}
