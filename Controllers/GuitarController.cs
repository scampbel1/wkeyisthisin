using Keyify.Business_Logic;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keyify.Controllers
{
    public class GuitarController : Controller
    {
        private readonly string _instrument = "Guitar";

        [HttpGet]
        public IActionResult Index()
        {
            var model = new FretboardWebModel();
            model.InstrumentName = _instrument;

            var test = HttpContext;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] notes, string scale)
        {
            FretboardWebModel model = new FretboardWebModel();
            model.InstrumentName = _instrument;

            if (notes == null || notes.Length < 1)
                return PartialView("Fretboard", model);

            FretboardFunctions.FindScales(model, scale, notes);

            return PartialView("Fretboard", model);
        }
    }
}
