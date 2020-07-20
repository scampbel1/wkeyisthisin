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

        private IScaleDictionaryService _dictionaryService;
        private IScaleDirectoryService _scaleDirectoryService;

        public MandolinController(IScaleDictionaryService dictionary, IScaleDirectoryService scaleDirectoryService)
        {
            _dictionaryService = dictionary;
            _scaleDirectoryService = scaleDirectoryService;
            _tuning = new StandardMandolinTuning();
        }

        [HttpGet]
        public ActionResult Index()
        {
            FretboardWebModel model = new FretboardWebModel(_fretCount, _tuning);
            model.InstrumentName = _instrumentName;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] selectedNotes, string selectedScale)
        {
            FretboardWebModel model = new FretboardWebModel(_fretCount, _tuning);
            model.InstrumentName = _instrumentName;

            if (selectedNotes == null || selectedNotes.Length < 1)
                return PartialView("Fretboard", model);

            FretboardFunctions.FindScales(model, selectedScale, selectedNotes, _dictionaryService, _scaleDirectoryService);

            return PartialView("Fretboard", model);
        }
    }
}