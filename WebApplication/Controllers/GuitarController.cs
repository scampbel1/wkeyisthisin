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

        private IScaleListService _dictionaryService;
        private IScaleService _scaleDirectoryService;

        public GuitarController(IScaleListService dictionary, IScaleService scaleDirectoryService, InstrumentViewModel instrumentViewModel)
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
            if (selectedNotes != null)
                FretboardFunctions.ProcessNotesAndScale(_model, selectedScale, selectedNotes, _dictionaryService, _scaleDirectoryService);

            return PartialView("Fretboard", _model);
        }
    }
}