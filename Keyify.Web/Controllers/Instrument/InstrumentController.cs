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
        public ActionResult UpdateFretboardModel(List<string> existingNoteSelections, string selectedNote, string selectedScale)
        {
            if (!string.IsNullOrWhiteSpace(selectedNote))
            {
                switch (existingNoteSelections.Contains(selectedNote))
                {
                    case true:
                        existingNoteSelections.Remove(selectedNote);
                        break;
                    case false:
                        existingNoteSelections.Add(selectedNote);
                        break;
                }
            }

            _instrumentViewModel.ProcessNotesAndScale(selectedScale, existingNoteSelections);
            _instrumentViewModel.ApplySelectedNotesToFretboard();

            return PartialView("Fretboard", _instrumentViewModel);
        }
    }
}