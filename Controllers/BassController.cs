using Microsoft.AspNetCore.Mvc;
using Keyify.Models;
using KeyifyWebClient.Core.Models;
using Keyify.Frontend_BuisnessLogic;
using KeyifyClassLibrary.Core.Domain.Tuning;
using Keyify.Domain.Tuning.Bass;

namespace Keyify.Controllers
{
    public class BassController : Controller
    {
        private readonly int _fretCount = 21;
        private readonly ITuning _tuning;
        private readonly string _instrument = "Bass";

        private IScaleDictionaryService _dictionaryService;

        public BassController(IScaleDictionaryService dictionary)
        {
            _dictionaryService = dictionary;
            _tuning = new StandardBassTuning();
        }

        public BassController(IScaleDictionaryService dictionary, ITuning tuning)
        {
            _dictionaryService = dictionary;
            _tuning = tuning;
        }

        [HttpGet]
        public ActionResult Index()
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
