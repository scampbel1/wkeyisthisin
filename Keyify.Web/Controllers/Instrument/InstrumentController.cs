using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Keyify.Controllers.Instrument
{
    public class InstrumentController : Controller
    {
        protected InstrumentViewModel _instrumentViewModel;

        public InstrumentController(InstrumentViewModel instrumentViewModel)
        {
            _instrumentViewModel = instrumentViewModel;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _instrumentViewModel.ApplySelectedNotesToFretboard();

            return View(_instrumentViewModel);
        }

        //TODO: Change this to PUT (?)
        [HttpPost]
        public ActionResult UpdateFretboardModel(List<string> previouslySelectedNotes, string newlySelectedNote, string selectedScale)
        {
            if (!string.IsNullOrWhiteSpace(newlySelectedNote) || previouslySelectedNotes != null)
            {
                if (!string.IsNullOrWhiteSpace(newlySelectedNote))
                {
                    if (previouslySelectedNotes.Contains(newlySelectedNote))
                    {
                        previouslySelectedNotes.Remove(newlySelectedNote);
                    }
                    else
                    {
                        previouslySelectedNotes.Add(newlySelectedNote);
                    }
                }

                _instrumentViewModel.ProcessNotesAndScale(selectedScale, previouslySelectedNotes);
            }

            return PartialView("Fretboard", _instrumentViewModel);
        }

        //TODO: Change this to POST (or most relevant method) - shouldn't be able to see parameters in the URL
        [HttpGet]
        public ActionResult QuickLink(List<string> selectedNotes, string selectedScale)
        {
            if (selectedNotes != null)
            {
                _instrumentViewModel.ProcessNotesAndScale(selectedScale, selectedNotes);
            }

            return View("Index", _instrumentViewModel);
        }
    }
}