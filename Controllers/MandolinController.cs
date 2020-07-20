using Microsoft.AspNetCore.Mvc;
using Keyify.Models;
using Keyify.Service;
using KeyifyWebClient.Core.Models;
using Keyify.FrontendBuisnessLogic;
using Keyify.Domain.Tuning.Mandolin;
using KeyifyClassLibrary.Core.Domain.Tuning;

namespace Keyify.Controllers
{
    public class MandolinController : Controller
    {
        private readonly int _fretCount = 20;
        private readonly ITuning _tuning;
        private readonly string _instrumentName = "Mandolin";

        FretboardWebModel _model;

        private IScaleDictionaryService _dictionaryService;
        private IScaleDirectoryService _scaleDirectoryService;

        public MandolinController(IScaleDictionaryService dictionary, IScaleDirectoryService scaleDirectoryService)
        {
            _dictionaryService = dictionary;
            _scaleDirectoryService = scaleDirectoryService;
            _tuning = new StandardMandolinTuning();
            _model = new FretboardWebModel(_fretCount, _tuning, _instrumentName);
        }

        //public BassController(IScaleDictionaryService dictionary, IScaleDirectoryService scaleDirectoryService, ITuning tuning)
        //{
        //    _dictionaryService = dictionary;
        //    _scaleDirectoryService = scaleDirectoryService;
        //    _tuning = tuning;
        //}

        [HttpGet]
        public ActionResult Index()
        {
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