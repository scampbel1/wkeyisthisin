using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.MusicTheory.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Keyify.Web.Controllers.Music_Theory
{
    public class ChordDefinitionController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Find([FromBody] ChordDefinitionCheckRequest request)
        {
            //TODO: Convert request param to intervalsResult
            var intervalsResult = new[] { Interval.WW, Interval.W, Interval.h };

            //TODO: Search for existing chord defintiion based on name and intervals

            //TODO: Handle name found, intervals found, or both

            var result = new { request.Name, Intervals = intervalsResult.Select(i => (int)i), Found = true };

            return Json(result);
        }

    }
}
