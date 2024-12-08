using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Web.Data_Contracts;
using Keyify.Web.Factories;
using Keyify.Web.Models.QuickLink;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Services.Interfaces;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
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
            try
            {
                var isLocked = (bool?)TempData["QLlocked"] ?? false;
                var selectedScale = (string)TempData["QLscale"];
                var selectedNotes = (IEnumerable<Note>)TempData["QLnotes"];
                var selectedInstrument = (int?)TempData["QLtype"] ?? Convert.ToInt32(InstrumentType.Guitar);

                //Model.Fretboard.UpdateFretboard(
                //    instrument.InstrumentType,
                //    instrument.Tuning,
                //    instrument.FretCount);

                // TODO: 
                //TempData[_configuration["QuickLinkTempDataKey:Tuning"]] = quickLink.Tuning;
                //TempData[_configuration["QuickLinkTempDataKey:InstrumentName"]] = quickLink.InstrumentName;

                await UpdateFretboard(
                    selectedNotes: selectedNotes?.ToArray(),
                    selectedScale,
                    isLocked,
                    instrumentType: (InstrumentType)selectedInstrument);
            }
            finally
            {
                ClearQuicklinkTempData();
            }

            return View(Model);
        }

        [HttpPost]
        [AllowAnonymous]
        [RequireAntiforgeryToken(true)]
        public async Task<ActionResult> UpdateFretboardModel([FromBody] UpdateFretboardRequest updateFretboardRequest)
        {
            try
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
                    lockFretboard: updateFretboardRequest.LockScale,
                    instrumentType: updateFretboardRequest.Instrument);

                return PartialView("Fretboard", Model);
            }
            finally
            {
                // TODO: Set timer for unpaid members
                // TODO: Set timer for unpaid members
#if !DEBUG
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(200));
#endif
            }
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

        private async Task UpdateFretboard(
            Note[] selectedNotes,
            string selectedScale,
            bool lockFretboard,
            InstrumentType instrumentType)
        {
            var instrument = InstrumentFactory.CreateInstrument(instrumentType);

            Model.Fretboard.UpdateFretboard(
                instrument.InstrumentType,
                instrument.Tuning,
                instrument.FretCount);

            if (selectedNotes != null)
            {
                _fretboardService.UpdateViewModel(
                    viewModel: Model,
                    selectedNotes,
                    selectedScale,
                    instrument.InstrumentType);
            }

            Model.IsSelectionLocked = lockFretboard;

            _fretboardService.UpdateUnlockedFretboard(Model);

            var quickLinkBase64 = _quickLinkService.ConvertQuickLinkToBase64(new QuickLink(Model));

            var availableScalesTableHtml = _scaleGroupingHtmlService.GenerateScalesTable(
                selectedNotes,
                Model.Fretboard.InstrumentType,
                Model.LimitedScaleGroup,
                selectedScale);

            Model.SetQuicklinkCode(quickLinkBase64);
            Model.UpdateAvailableScalesTableHtml(availableScalesTableHtml);

            if (selectedScale != null)
            {
                await SetChordDefinitions(selectedNotes);
            }

            // TODO: Set these on startup
            Model.ScalePopularityIconLegendHtml = SetScaleResultLegendHtml();
            Model.ChordPopularityIconLegendHtml = SetChordResultLegendHtml();
            Model.NoteSelectionIconLegendHtml = SetNoteColourLegendHtml();

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

        private string SetChordResultLegendHtml()
        {
            if (!Model.ChordDefinitions.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            foreach (var popularity in new int[] { 1, 2, 3, 4 })
            {
                var (label, icon) = _chordDefinitionsGroupingHtmlService.GetChordPopularityIcon(popularity);

                sb.Append($"<span>{icon}{label} </span>");
            }

            return sb.ToString().TrimEnd();
        }

        private string SetScaleResultLegendHtml()
        {
            if (!Model.AvailableScaleGroups.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            foreach (var popularity in new int[] { 0, 1, 2, 3, 4, 5 })
            {
                var (label, icon) = _scaleGroupingHtmlService.GetScalePopularityIcon(popularity);

                sb.Append($"<span>{icon}{label} </span>");
            }

            return sb.ToString().TrimEnd();
        }

        private string SetNoteColourLegendHtml()
        {
            var sb = new StringBuilder();

            sb.AppendLine("<div style=\"display:flex; gap:5px; float:right;\">");

            foreach (var noteColourIndex in new int[] { 2, 3, 4, 5 })
            {
                var (description, cssClass) = GetNoteColourMapping(noteColourIndex);

                sb.AppendLine($"<span class=\"color-box {cssClass}\"></span>");
                sb.Append($"<span>{description}</span>");
            }

            sb.AppendLine("</div>");

            return sb.ToString();
        }

        private (string, string) GetNoteColourMapping(int noteColourIndex)
        {
            switch (noteColourIndex)
            {
                case 1:
                    return ("Unselected", "defaultNote");
                case 2:
                    return ("Selected", "selectedNote");
                case 3:
                    return ("Note in Scale", "noteSelectedScale");
                case 4:
                    return ("Selected Note in Scale", "selectedNoteSelectedScale");
                case 5:
                    return ("Locked Scale Note", "lockedNoteSelectedScale");
                default:
                    return ("Unknown", $"{noteColourIndex}");
            }
        }
    }
}