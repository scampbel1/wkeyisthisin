using Microsoft.AspNetCore.Mvc;
using Keyify.Models;
using Keyify.Frontend_BuisnessLogic;
using KeyifyWebClient.Core.Models;

namespace Keyify.Controllers
{
    public class GuitarController : Controller
    {
        private readonly string _instrument = "Guitar";

        private IScaleDictionaryService _dictionaryService;

        public GuitarController(IScaleDictionaryService dictionary)
        {
            _dictionaryService = dictionary;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new FretboardWebModel();
            model.InstrumentName = _instrument;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] notes, string scale)
        {
            FretboardWebModel model = new FretboardWebModel();
            model.InstrumentName = _instrument;

            if (notes == null || notes.Length < 1)
                return PartialView("Fretboard", model);

            FretboardFunctions.FindScales(model, scale, notes, _dictionaryService);

            return PartialView("Fretboard", model);
        }
    }
}
