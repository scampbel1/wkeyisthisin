using Keyify.Web.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Keyify.Controllers.Instrument
{
    public class InstrumentController : Controller
    {
        private IMusicTheoryService _musicTheoryService;
        private IFretboardService _fretboardService;

        protected InstrumentViewModel Model;

        public InstrumentController(InstrumentViewModel model, IMusicTheoryService musicTheoryService, IFretboardService fretboardService)
        {
            Model = model;
            _musicTheoryService = musicTheoryService;
            _fretboardService = fretboardService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var selectedScale = (string)TempData["QLscale"];
            var selectedNotes = (IEnumerable<Note>)TempData["QLnotes"];

            if (selectedNotes != null)
            {
                _fretboardService.ProcessNotesAndScale(Model, selectedNotes, selectedScale);
            }

            _fretboardService.ApplyNotesToFretboard(Model.Fretboard, Model.SelectedNotes, Model.SelectedScale);

            return View(Model);
        }

        [HttpPost]
        //DON'T CHANGE THE NAMES OF THESE PARAMETERS
        public ActionResult UpdateFretboardModel(List<Note> previouslySelectedNotes, Note? newlySelectedNote, string selectedScale)
        {
            if (newlySelectedNote != null)
            {
                switch (previouslySelectedNotes.Contains(newlySelectedNote.Value))
                {
                    case true:
                        previouslySelectedNotes.Remove(newlySelectedNote.Value);
                        break;
                    case false:
                        previouslySelectedNotes.Add(newlySelectedNote.Value);
                        break;
                }
            }

            _fretboardService.ProcessNotesAndScale(Model, previouslySelectedNotes, selectedScale);

            _fretboardService.ApplyNotesToFretboard(Model.Fretboard, Model.SelectedNotes, Model.SelectedScale);

            return PartialView("Fretboard", Model);
        }

        [HttpPost]
        public ActionResult LockSelection(string selectedScale, Note[] selectedNotes)
        {
            Model.IsSelectionLocked = true;

            var chordTemplates = _musicTheoryService.GetChordsTemplates(selectedScale, selectedNotes);

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