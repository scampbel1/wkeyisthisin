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
        private readonly string _instrumentName = "Guitar";
        private readonly int _fretCount = 24;

        FretboardWebModel _model;

        private IScaleDictionaryService _dictionaryService;
        private IScaleDirectoryService _scaleDirectoryService;

        public GuitarController(IScaleDictionaryService dictionary, IScaleDirectoryService scaleDirectoryService)
        {
            _dictionaryService = dictionary;
            _scaleDirectoryService = scaleDirectoryService;
            _tuning = new StandardGuitarTuning();
            _model = new FretboardWebModel(_fretCount, _tuning, _instrumentName);
        }

        [HttpGet]
        public IActionResult Index()
        {
            _model.InstrumentName = _instrumentName;

            return View(_model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] selectedNotes, string selectedScale)
        {
            if (selectedNotes == null || selectedNotes.Length < 1)
                return PartialView("Fretboard", _model);

            FretboardFunctions.FindScales(_model, selectedScale, selectedNotes, _dictionaryService, _scaleDirectoryService);

            return PartialView("Fretboard", _model);
        }
    }
}
