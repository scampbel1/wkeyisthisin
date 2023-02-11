using Keyify.Web.Models.QuickLink;
using Keyify.Web.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Controllers.Instrument
{
    public class InstrumentController : Controller
    {
        private IMusicTheoryService _musicTheoryService;
        private IFretboardService _fretboardService;
        private IScaleGroupingHtmlService _scaleGroupingHtmlService;
        private IQuickLinkService _quickLinkService;

        protected InstrumentViewModel Model;

        public InstrumentController(InstrumentViewModel model, IMusicTheoryService musicTheoryService, IFretboardService fretboardService, IScaleGroupingHtmlService scaleGroupingHtmlService, IQuickLinkService quickLinkService)
        {
            Model = model;
            _musicTheoryService = musicTheoryService;
            _fretboardService = fretboardService;
            _scaleGroupingHtmlService = scaleGroupingHtmlService;
            _quickLinkService = quickLinkService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var selectedScale = (string)TempData["QLscale"];
            var selectedNotes = (IEnumerable<Note>)TempData["QLnotes"];

            UpdateFretboard(selectedNotes?.ToArray(), selectedScale);

            return View(Model);
        }

        [HttpPost]
        //DON'T CHANGE THE NAMES OF THESE PARAMETERS
        public ActionResult UpdateFretboardModel(List<Note> previouslySelectedNotes, Note? newlySelectedNote, string selectedScale)
        {
            if (newlySelectedNote.HasValue)
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

            UpdateFretboard(previouslySelectedNotes.ToArray(), selectedScale);

            return PartialView("Fretboard", Model);
        }

        [HttpPost]
        public ActionResult ToggleLockSelection(string selectedScale, Note[] selectedNotes, bool lockSelection)
        {
            Model.IsSelectionLocked = lockSelection;

            UpdateFretboard(selectedNotes, selectedScale);

            if (lockSelection)
            {
                Model.ChordTemplates = _musicTheoryService.GetChordsTemplates(Model.SelectedScale?.Scale?.Notes?.ToArray(), selectedNotes).ToList();
            }

            return PartialView("Fretboard", Model);
        }

        //TODO: Move all of this out of the controller
        private void UpdateFretboard(Note[] selectedNotes, string selectedScale)
        {
            if (selectedNotes != null)
            {
                _fretboardService.ProcessNotesAndScale(Model, selectedNotes, selectedScale);
            }

            _fretboardService.ApplyNotesToFretboard(Model.Fretboard, Model.SelectedNotes, Model.SelectedScale);

            Model.AvailableKeysAndScalesTableHtml = _scaleGroupingHtmlService.GenerateAvailableKeysAndScalesTable(selectedNotes, Model.Fretboard.InstrumentType, Model.AvailableKeyGroups, Model.AvailableScaleGroups);

            Model.UpdateQuickLinkCode(_quickLinkService.ConvertQuickLinkToBase64(new QuickLink(Model)));
        }
    }
}