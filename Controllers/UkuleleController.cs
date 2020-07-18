using Microsoft.AspNetCore.Mvc;
using Keyify.Models;
using KeyifyWebClient.Core.Models;
using Keyify.Frontend_BuisnessLogic;
using Keyify.Domain.Tuning.Ukulele;
using KeyifyClassLibrary.Core.Domain.Tuning;

namespace Keyify.Controllers
{
    public class UkuleleController : Controller
    {
        private readonly ITuning _tuning;
        private readonly int _fretCount = 13;
        private readonly string _instrument = "Ukulele";

        private IScaleDictionaryService _dictionaryService;

        public UkuleleController(IScaleDictionaryService dictionary)
        {
            _dictionaryService = dictionary;
            _tuning = new StandardUkuleleTuning();
        }

        public UkuleleController(IScaleDictionaryService dictionary, ITuning tuning)
        {
            _dictionaryService = dictionary;
            _tuning = tuning;
        }

        [HttpGet]
        public IActionResult Index()
        {
            FretboardWebModel model = new FretboardWebModel(_fretCount, _tuning);
            model.InstrumentName = _instrument;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] notes, string scale)
        {
            FretboardWebModel model = new FretboardWebModel(_fretCount, _tuning);
            model.InstrumentName = _instrument;

            if (notes == null || notes.Length < 1)
                return PartialView("Fretboard", model);

            FretboardFunctions.FindScales(model, scale, notes, _dictionaryService);

            return PartialView("Fretboard", model);
        }
    }
}