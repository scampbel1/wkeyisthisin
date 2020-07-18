using Microsoft.AspNetCore.Mvc;
using Keyify.Models;
using Keyify.Service;
using KeyifyWebClient.Core.Models;
using Keyify.FrontendBuisnessLogic;
using KeyifyClassLibrary.Core.Domain.Tuning;
using KeyifyClassLibrary.Core.Domain.Tuning.Guitar;

namespace Keyify.Controllers
{
    public class GuitarController : Controller
    {
        private readonly ITuning _tuning;
        private readonly string _instrument = "Guitar";
        private readonly int _fretCount = 24;

        private IScaleDictionaryService _dictionaryService;
        private IScaleDirectoryService _scaleDirectoryService;

        public GuitarController(IScaleDictionaryService dictionary, IScaleDirectoryService scaleDirectoryService)
        {
            _dictionaryService = dictionary;
            _scaleDirectoryService = scaleDirectoryService;
            _tuning = new StandardGuitarTuning();
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

            FretboardFunctions.FindScales(model, scale, notes, _dictionaryService, _scaleDirectoryService);

            return PartialView("Fretboard", model);
        }
    }
}
