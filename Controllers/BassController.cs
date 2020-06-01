using Keyify.Business_Logic;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Tuning.Guitar;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keyify.Controllers
{
    public class BassController : Controller
    {
        private readonly int _fretCount = 21;
        private readonly Note[] _tuning = new Note[] { Note.E, Note.A, Note.D, Note.G };
        private readonly string _instrument = "Bass";

        [HttpGet]
        public ActionResult Index()
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

            FretboardFunctions.FindScales(model, scale, notes);

            return PartialView("Fretboard", model);
        }
    }
}
