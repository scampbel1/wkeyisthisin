using Keyify.Web.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Keyify.Web.Controllers.Quicklink
{
    public class QuickLinkController : Controller
    {
        private IConfiguration _configuration;
        private IQuickLinkService _quickLinkService;

        public QuickLinkController(IConfiguration configuration, IQuickLinkService quickLinkService)
        {
            _configuration = configuration;
            _quickLinkService = quickLinkService;
        }

        [HttpGet("/{code}")]
        public IActionResult Index(string code)
        {
            var quickLink = _quickLinkService.DeserializeQuickLink(code);

            TempData[_configuration["QuickLinkTempDataKey:Tuning"]] = quickLink.Tuning;
            TempData[_configuration["QuickLinkTempDataKey:SelectedScale"]] = quickLink.SelectedScale;
            TempData[_configuration["QuickLinkTempDataKey:SelectedNotes"]] = quickLink.SelectedNotes;
            TempData[_configuration["QuickLinkTempDataKey:InstrumentType"]] = quickLink.InstrumentType;
            TempData[_configuration["QuickLinkTempDataKey:InstrumentName"]] = quickLink.InstrumentName;

            return RedirectToAction("Index", quickLink.InstrumentName);
        }
    }
}
