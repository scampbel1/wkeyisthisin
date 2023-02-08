using KeyifyClassLibrary.Enums;
using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Controllers.Instrument
{
    public class InstrumentController : Controller
    {
        protected InstrumentViewModel ViewModel;

        public InstrumentController(InstrumentViewModel instrumentViewModel)
        {
            ViewModel = instrumentViewModel;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var selectedNotes = (IEnumerable<Note>)TempData["QLnotes"];
            var selectedScale = (string)TempData["QLscale"];

            if (selectedNotes != null)
            {
                ViewModel.ProcessNotesAndScale(selectedScale, selectedNotes.Select(n => n.ToString()));
            }

            ViewModel.ApplySelectedNotesToFretboard();

            return View(ViewModel);
        }

        [HttpPost]
        //DON'T CHANGE THE NAMES OF THESE PARAMETERS
        public ActionResult UpdateFretboardModel(List<string> previouslySelectedNotes, string newlySelectedNote, string selectedScale)
        {
            if (!string.IsNullOrWhiteSpace(newlySelectedNote))
            {
                switch (previouslySelectedNotes.Contains(newlySelectedNote))
                {
                    case true:
                        previouslySelectedNotes.Remove(newlySelectedNote);
                        break;
                    case false:
                        previouslySelectedNotes.Add(newlySelectedNote);
                        break;
                }
            }

            ViewModel.ProcessNotesAndScale(selectedScale, previouslySelectedNotes);
            ViewModel.ApplySelectedNotesToFretboard();

            return PartialView("Fretboard", ViewModel);
        }

        [HttpPost]
        public ActionResult LockSelection(List<string> selectedNotes, string selectedScale)
        {
            ViewModel.IsSelectionLocked = true;

            return PartialView("Fretboard", ViewModel);
        }

        [HttpPost]
        public ActionResult UnockSelection()
        {
            ViewModel.IsSelectionLocked = false;

            return PartialView("Fretboard", ViewModel);
        }
    }
}