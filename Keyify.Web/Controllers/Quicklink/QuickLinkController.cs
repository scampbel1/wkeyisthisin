using Keyify.Web.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Keyify.Web.Controllers.Quicklink
{
    public class QuickLinkController : Controller
    {
        private IQuickLinkService _quickLinkService;

        public QuickLinkController(IQuickLinkService quickLinkService)
        {
            _quickLinkService = quickLinkService;
        }

        [HttpGet("/{code}")]
        public IActionResult Index(string code)
        {
            var quickLink = _quickLinkService.GenerateQuickLinkFromBase64String(code);

            return RedirectToAction("QuickLink", quickLink.InstrumentName, new { selectedNotes = quickLink.SelectedNotes, selectedScale = quickLink.SelectedScale });
        }
    }
}
