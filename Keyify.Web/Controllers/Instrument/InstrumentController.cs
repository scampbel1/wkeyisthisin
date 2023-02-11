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

            if (selectedNotes != null)
            {
                _fretboardService.ProcessNotesAndScale(Model, selectedNotes, selectedScale);
            }

            _fretboardService.ApplyNotesToFretboard(Model.Fretboard, Model.SelectedNotes, Model.SelectedScale);

            Model.AvailableKeysAndScalesTableHtml = _scaleGroupingHtmlService.GenerateAvailableKeysAndScalesTable(selectedNotes, Model.Fretboard.InstrumentType, Model.AvailableKeyGroups, Model.AvailableScaleGroups);

            Model.UpdateQuickLinkCode(_quickLinkService.ConvertQuickLinkToBase64(new QuickLink(Model)));

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

            _fretboardService.ProcessNotesAndScale(Model, previouslySelectedNotes, selectedScale);

            _fretboardService.ApplyNotesToFretboard(Model.Fretboard, Model.SelectedNotes, Model.SelectedScale);

            Model.AvailableKeysAndScalesTableHtml = _scaleGroupingHtmlService.GenerateAvailableKeysAndScalesTable(previouslySelectedNotes, Model.Fretboard.InstrumentType, Model.AvailableKeyGroups, Model.AvailableScaleGroups);

            Model.UpdateQuickLinkCode(_quickLinkService.ConvertQuickLinkToBase64(new QuickLink(Model)));

            return PartialView("Fretboard", Model);
        }

        [HttpPost]
        public ActionResult ToggleLockSelection(string selectedScale, Note[] selectedNotes, bool lockSelection)
        {
            if (lockSelection)
            {
                Model.ChordTemplates = _musicTheoryService.GetChordsTemplates(selectedScale, selectedNotes).ToList();
            }

            Model.IsSelectionLocked = lockSelection;

            return PartialView("Fretboard", Model);
        }
    }
}