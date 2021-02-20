using Keyify.FrontendBuisnessLogic;
using Keyify.Models;
using Keyify.Service;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keyify.Controllers
{

    public class InstrumentController : Controller
    {
        protected IScaleListService _dictionaryService;
        protected IScaleService _scaleDirectoryService;
        protected InstrumentViewModel _instrumentViewModel;

        public InstrumentController(IScaleListService dictionary, IScaleService scaleDirectoryService, InstrumentViewModel instrumentViewModel)
        {
            _scaleDirectoryService = scaleDirectoryService;
            _dictionaryService = dictionary;
            _instrumentViewModel = instrumentViewModel;
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] selectedNotes, string selectedScale)
        {
            if (selectedNotes != null)
                FretboardFunctions.ProcessNotesAndScale(_instrumentViewModel, selectedScale, selectedNotes, _dictionaryService, _scaleDirectoryService);

            return PartialView("Fretboard", _instrumentViewModel);
        }
    }
}
