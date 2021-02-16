using Keyify.FrontendBuisnessLogic;
using Keyify.Models;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain.Tuning;
using KeyifyClassLibrary.Core.Domain.Tuning.Guitar;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keyify.Controllers
{
    public class GuitarController : Controller
    {
        private readonly ITuning _tuning;
        private readonly string _instrumentName = "Guitar";
        private readonly int _fretCount = 24;

        private InstrumentViewModel _model;

        private IScaleDictionaryService _dictionaryService;
        private IScaleDirectoryService _scaleDirectoryService;

        public GuitarController(IScaleDictionaryService dictionary, IScaleDirectoryService scaleDirectoryService, InstrumentViewModel instrumentViewModel)
        {
            _dictionaryService = dictionary;
            _scaleDirectoryService = scaleDirectoryService;

            _tuning = new StandardGuitarTuning();

            _model = instrumentViewModel;
            _model.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] selectedNotes, string selectedScale)
        {
            if (selectedNotes != null && selectedNotes.Length > 0)
                FretboardFunctions.FindScales(_model, selectedScale, selectedNotes, _dictionaryService, _scaleDirectoryService);

            return PartialView("Fretboard", _model);
        }
    }
}
