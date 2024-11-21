using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Web.Models.QuickLink;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<ActionResult> Index()
        {
            var selectedScale = (string)TempData["QLscale"];
            var selectedNotes = (IEnumerable<Note>)TempData["QLnotes"];

            await UpdateFretboard(selectedNotes?.ToArray(), selectedScale);

            return View(Model);
        }

        [HttpPost]
        //DON'T CHANGE THE NAMES OF THESE PARAMETERS
        public async Task<ActionResult> UpdateFretboardModel(List<Note> previouslySelectedNotes, Note? newlySelectedNote, string selectedScale, bool lockScale)
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

            await UpdateFretboard(previouslySelectedNotes.ToArray(), selectedScale);

            return PartialView("Fretboard", Model);
        }

        [HttpPost]
        public async Task<ActionResult> ToggleLockSelection(string selectedScale, Note[] selectedNotes, bool lockSelection)
        {
            Model.IsSelectionLocked = lockSelection;

            await UpdateFretboard(selectedNotes, selectedScale);

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

            var availableScalesTableHtml = _scaleGroupingHtmlService.GenerateScalesTable(
                selectedNotes,
                Model.Fretboard.InstrumentType,
                Model.LimitedScaleGroup,
                selectedScale);

            Model.UpdateQuickLinkCode(quickLinkBase64);
            Model.UpdateAvailableScalesTableHtml(availableScalesTableHtml);


            if (selectedScale != null)
            {
                await SetChordDefinitions(selectedNotes);
            }

            // TODO: Set this on startup
            Model.PopularityIconLegend = SetLegend();

            async Task SetChordDefinitions(Note[] selectedNotes)
            {
                var selectedScaleNotes = Model.SelectedScale?.Scale?.Notes?.ToArray();

                var chordDefintions = await _musicTheoryService
                    .GetChordsDefinitions(selectedScaleNotes, selectedNotes);

                Model.ChordDefinitions = chordDefintions.ToList();

                var availableChordDefinitionsHtml = _chordDefinitionsGroupingHtmlService
                    .GenerateChordDefinitionsHtml(Model.ChordDefinitions);

                Model.UpdateAvailableChordDefinitionsHtml(availableChordDefinitionsHtml);
            }
        }

        private string SetLegend()
        {
            if (!Model.AvailableScaleGroups.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            foreach (var popularity in new int[] { 0, 1, 2, 3, 4 })
            {
                var (label, icon) = _scaleGroupingHtmlService.GetScalePopularityIcon(popularity);

                sb.Append($"{icon}{label} ");
            }

            return sb.ToString().TrimEnd();
        }
    }
}