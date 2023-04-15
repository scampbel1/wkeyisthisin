using Microsoft.AspNetCore.Mvc;

namespace Keyify.Web.Controllers.Music_Theory
{
    public class ChordTemplateController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Find([FromBody] string chordDefinitionName)
        {
            var result = new { Name = chordDefinitionName, Found = true };

            return Json(result);
        }
    }
}
