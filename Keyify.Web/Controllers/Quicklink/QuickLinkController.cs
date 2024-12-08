using Keyify.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Keyify.Web.Controllers.Quicklink
{
    public class QuickLinkController(IConfiguration configuration, IQuickLinkService quickLinkService) : Controller
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IQuickLinkService _quickLinkService = quickLinkService;

        [HttpGet("/ql/v1/{code}")]
        public IActionResult Index(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Redirect("/");
            }

            var quickLink = _quickLinkService.DeserializeQuickLink(code);

            TempData[_configuration["QuickLinkTempDataKey:Tuning"]] = quickLink.Tuning;
            TempData[_configuration["QuickLinkTempDataKey:SelectedScale"]] = quickLink.SelectedScale;
            TempData[_configuration["QuickLinkTempDataKey:SelectedNotes"]] = quickLink.SelectedNotes;
            TempData[_configuration["QuickLinkTempDataKey:InstrumentType"]] = quickLink.InstrumentType;
            TempData[_configuration["QuickLinkTempDataKey:IsLocked"]] = quickLink.IsLocked;

            return Redirect("/");
        }
    }
}
