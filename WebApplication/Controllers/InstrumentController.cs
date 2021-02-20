using Keyify.FrontendBuisnessLogic;
using Keyify.Models;
using Keyify.Service;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult UpdateFretboardModel(List<string> previouslySelectedNotes, string newlySelectedNote, string selectedScale)
        {
            if (!string.IsNullOrWhiteSpace(newlySelectedNote) || previouslySelectedNotes != null)
            {
                if (!string.IsNullOrWhiteSpace(newlySelectedNote))
                {
                    if (!previouslySelectedNotes.Contains(newlySelectedNote))
                    {
                        previouslySelectedNotes.Add(newlySelectedNote);
                    }
                    else
                    {
                        previouslySelectedNotes.Remove(newlySelectedNote);
                    }
                }

                FretboardFunctions.ProcessNotesAndScale(_instrumentViewModel, selectedScale, previouslySelectedNotes, _dictionaryService, _scaleDirectoryService);
            }

            return PartialView("Fretboard", _instrumentViewModel);
        }

        [HttpGet]
        public ActionResult Index()
        {
            //TODO: Make this an accessible class (this code should be getting called everytime a page is hit from elsewhere... you're used to hitting the UpdateFredboardModel method)
            _instrumentViewModel.ApplySelectedNotesToFretboard(_instrumentViewModel.SelectedNotes.Select(a => a.Note).ToList(), _instrumentViewModel.SelectedScale?.Scale.NotesSet);

            return View(_instrumentViewModel);
        }
    }
}
