using KeyifyClassLibrary.Enums;
using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Controllers.Instrument
{
    public class InstrumentController : Controller
    {
        protected InstrumentViewModel Model;

        public InstrumentController(InstrumentViewModel instrumentViewModel)
        {
            Model = instrumentViewModel;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var selectedNotes = (IEnumerable<Note>)TempData["QLnotes"];
            var selectedScale = (string)TempData["QLscale"];

            if (selectedNotes != null)
            {
                Model.ProcessNotesAndScale(selectedScale, selectedNotes.Select(n => n.ToString()));
            }

            Model.ApplySelectedNotesToFretboard();

            return View(Model);
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

            Model.ProcessNotesAndScale(selectedScale, previouslySelectedNotes);
            Model.ApplySelectedNotesToFretboard();

            return PartialView("Fretboard", Model);
        }

        [HttpPost]
        public ActionResult LockSelection(string selectedScale, Note[] selectedNotes)
        {
            Model.IsSelectionLocked = true;

            var chordTemplates = Model.GetChordsTemplatesForSelection(selectedScale, selectedNotes);

            return PartialView("Fretboard", Model);
        }

        [HttpPost]
        public ActionResult UnockSelection(string selectedScale, Note[] selectedNotes)
        {
            Model.IsSelectionLocked = false;

            return PartialView("Fretboard", Model);
        }
    }
}