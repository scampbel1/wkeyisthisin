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
                _instrumentViewModel.ApplySelectedNotesToFretboard();
            }

            return PartialView("Fretboard", _instrumentViewModel);
        }
    }
}