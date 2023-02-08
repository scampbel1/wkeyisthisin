using KeyifyClassLibrary.Enums;
using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
            var selectedNotes = (IEnumerable<Note>)TempData["QLnotes"];
            var selectedScale = (string)TempData["QLscale"];

            if (selectedNotes != null)
            {
                _instrumentViewModel.ProcessNotesAndScale(selectedScale, selectedNotes.Select(n => n.ToString()));
            }

            _instrumentViewModel.ApplySelectedNotesToFretboard();

            return View(_instrumentViewModel);
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

            _instrumentViewModel.ProcessNotesAndScale(selectedScale, previouslySelectedNotes);
            _instrumentViewModel.ApplySelectedNotesToFretboard();

            return PartialView("Fretboard", _instrumentViewModel);
        }

        [HttpPost]
        public ActionResult LockChordSelection(List<string> selectedNotes, string selectedScale)
        {
            return PartialView("Fretboard", _instrumentViewModel);
        }
    }
}