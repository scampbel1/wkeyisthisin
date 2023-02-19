using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Web.Models.QuickLink;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Service.Interfaces;
using Keyify.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keyify.Controllers.Instrument
{
    public class InstrumentController : Controller
    {
        private readonly IMusicTheoryService _musicTheoryService;
        private readonly IFretboardService _fretboardService;
        private readonly IScaleGroupingHtmlService _scaleGroupingHtmlService;
        private readonly IQuickLinkService _quickLinkService;
        private readonly IChordDefinitionGroupingHtmlService _chordDefinitionsGroupingHtmlService;

        protected InstrumentViewModel Model;

        public InstrumentController(InstrumentViewModel model, IMusicTheoryService musicTheoryService, IFretboardService fretboardService, IScaleGroupingHtmlService scaleGroupingHtmlService, IQuickLinkService quickLinkService, IChordDefinitionGroupingHtmlService chordDefinitionsGroupingHtmlService)
        {
            Model = model;
            _musicTheoryService = musicTheoryService;
            _fretboardService = fretboardService;
            _scaleGroupingHtmlService = scaleGroupingHtmlService;
            _quickLinkService = quickLinkService;
            _chordDefinitionsGroupingHtmlService = chordDefinitionsGroupingHtmlService;
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

            }

            return PartialView("Fretboard", Model);
        }

        //TODO: Move all of this out of the controller
        private async Task UpdateFretboard(Note[] selectedNotes, string selectedScale)
        {
            if (selectedNotes != null)
            {
                _fretboardService.UpdateViewModel(Model, selectedNotes, selectedScale);
            }

            _fretboardService.UpdateFretboard(Model);

            var quickLink = new QuickLink(Model);
            var quickLinkBase64 = _quickLinkService.ConvertQuickLinkToBase64(quickLink);
            var availableKeysAndScalesTableHtml = _scaleGroupingHtmlService.GenerateAvailableKeysAndScalesTable(selectedNotes, Model.Fretboard.InstrumentType, Model.AvailableKeyGroups, Model.AvailableScaleGroups);

            Model.UpdateQuickLinkCode(quickLinkBase64);
            Model.UpdateAvailableKeysAndScalesTableHtml(availableKeysAndScalesTableHtml);

            var chordDefintiions = await _musicTheoryService.GetChordsDefinitions(Model.SelectedScale?.Scale?.Notes?.ToArray(), selectedNotes);
            var availableChordDefinitionsTableHtml = _chordDefinitionsGroupingHtmlService.GenerateChordDefinitionsTableHtml(chordDefintiions);

            Model.ChordDefinitions = chordDefintiions.ToList();
            Model.UpdateAvailableChordDefinitionsTableHtml(availableChordDefinitionsTableHtml);
        }
    }
}