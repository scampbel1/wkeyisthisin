using Keyify.Business_Logic;
using Keyify.Models;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Tuning.Guitar;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keyify.Controllers
{
    public class UkuleleController : Controller
    {
        private readonly int _fretCount = 13;
        private readonly Note[] _tuning = new Note[] { Note.G, Note.C, Note.E, Note.A };
        private readonly string _instrument = "Ukulele";

        private IScaleDictionaryService _dictionaryService;

        public UkuleleController(IScaleDictionaryService dictionary)
        {
            _dictionaryService = dictionary;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new FretboardWebModel(_fretCount, new CustomStandardGuitarTuning(_tuning));
            model.InstrumentName = _instrument;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] notes, string scale)
        {
            FretboardWebModel model = new FretboardWebModel(_fretCount, new CustomStandardGuitarTuning(_tuning));
            model.InstrumentName = _instrument;

            if (notes == null || notes.Length < 1)
                return PartialView("Fretboard", model);

            FretboardFunctions.FindScales(model, scale, notes, _dictionaryService);

            return PartialView("Fretboard", model);
        }
    }
}