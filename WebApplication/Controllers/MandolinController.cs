using Keyify.Domain.Tuning.Mandolin;
using Keyify.FrontendBuisnessLogic;
using Keyify.Models;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain.Tuning;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keyify.Controllers
{
    public class MandolinController : Controller
    {
        private readonly ITuning _tuning;
        private readonly int _fretCount = 20;
        private readonly string _instrumentName = "Mandolin";

        InstrumentViewModel _model;

        private IScaleListService _dictionaryService;
        private IScaleService _scaleDirectoryService;

        public MandolinController(IScaleListService dictionary, IScaleService scaleDirectoryService, InstrumentViewModel instrumentViewModel)
        {
            _dictionaryService = dictionary;
            _scaleDirectoryService = scaleDirectoryService;

            _tuning = new StandardMandolinTuning();

            _model = instrumentViewModel;
            _model.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }

        [HttpGet]
        public ActionResult Index()
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