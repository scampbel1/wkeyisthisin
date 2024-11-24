using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Web.Data_Contracts;
using Keyify.Web.Models.QuickLink;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyify.Web.Controllers.Instrument
{
    public class InstrumentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMusicTheoryService _musicTheoryService;
        private readonly IFretboardService _fretboardService;
        private readonly IScaleGroupingHtmlService _scaleGroupingHtmlService;
        private readonly IQuickLinkService _quickLinkService;
        private readonly IChordDefinitionGroupingHtmlService _chordDefinitionsGroupingHtmlService;

        protected InstrumentViewModel Model;

        public InstrumentController(
            InstrumentViewModel model,
            IConfiguration configuration,
            IMusicTheoryService musicTheoryService,
            IFretboardService fretboardService,
            IScaleGroupingHtmlService scaleGroupingHtmlService,
            IQuickLinkService quickLinkService,
            IChordDefinitionGroupingHtmlService chordDefinitionsGroupingHtmlService)
        {
            Model = model;
            _configuration = configuration;
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

            ClearQuicklinkTempData();

            await UpdateFretboard(selectedNotes?.ToArray(), selectedScale, false);

            return View(Model);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateFretboardModel([FromBody] UpdateFretboardRequest updateFretboardRequest)
        {
            if (updateFretboardRequest?.NewlySelectedNote != null)
            {
                var newlySelectedNote = updateFretboardRequest.NewlySelectedNote;

                switch (updateFretboardRequest.PreviouslySelectedNotes.Contains(newlySelectedNote.Value))
                {
                    case true:
                        updateFretboardRequest.PreviouslySelectedNotes.Remove(newlySelectedNote.Value);
                        break;
                    case false:
                        updateFretboardRequest.PreviouslySelectedNotes.Add(newlySelectedNote.Value);
                        break;
                }
            }

            await UpdateFretboard(
                selectedNotes: updateFretboardRequest.PreviouslySelectedNotes?.ToArray() ?? [],
                selectedScale: updateFretboardRequest.SelectedScale,
                lockFretboard: updateFretboardRequest.LockScale);

            return PartialView("Fretboard", Model);
        }


        private void ClearQuicklinkTempData()
        {
            if (TempData.Any())
            {
                foreach (var tempData in TempData.Where(d => d.Key.StartsWith("QL")).ToList())
                {
                    TempData.Remove(tempData.Key);
                }
            }
        }

        private async Task UpdateFretboard(Note[] selectedNotes, string selectedScale, bool lockFretboard)
        {
            if (selectedNotes != null)
            {
                _fretboardService.UpdateViewModel(Model, selectedNotes, selectedScale);
            }

            Model.IsSelectionLocked = lockFretboard;

            if (!Model.IsSelectionLocked)
            {
                _fretboardService.UpdateUnlockedFretboard(Model);
            }

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
            Model.ScalePopularityIconLegend = SetScaleResultLegend();

            Model.ChordPopularityIconLegend = SetChordResultLegend();

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

        private string SetChordResultLegend()
        {
            if (!Model.ChordDefinitions.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            foreach (var popularity in new int[] { 1, 2, 3, 4 })
            {
                var (label, icon) = _chordDefinitionsGroupingHtmlService.GetChordPopularityIcon(popularity);

                sb.Append($"{icon}{label} ");
            }

            return sb.ToString().TrimEnd();
        }

        private string SetScaleResultLegend()
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