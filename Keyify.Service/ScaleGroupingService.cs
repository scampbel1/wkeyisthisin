using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Models;
using Keyify.Web.Services.Interfaces;
using System.Text;

namespace Keyify.Web.Service
{
    public class ScaleGroupingService : IScaleGroupingService
    {
        private readonly INoteFormatService _noteFormatService;
        private readonly Dictionary<Note, string> _sharpNoteDictionary;

        public ScaleGroupingService(INoteFormatService noteFormatService)
        {
            _noteFormatService = noteFormatService;
            _sharpNoteDictionary = _noteFormatService.SharpNoteDictionary;
        }

        public string GenerateScalesTable(
            IEnumerable<Note> selectedNotes,
            InstrumentType instrumentType,
            List<ScaleGroupingEntry> availableScaleGroups,
            string selectedScale)
        {
            if (!availableScaleGroups.Any())
            {
                return string.Empty;
            }

            var limitedGroupScale = availableScaleGroups.Take(8).ToList();

            var sb = new StringBuilder();

            sb.Append("<table class=\"scaleTable\">");

            GenerateScales(
                selectedNotes,
                instrumentType,
                limitedGroupScale,
                selectedScale,
                sb);

            sb.Append("</table>");

            return sb.ToString();

            void GenerateScales(
                IEnumerable<Note> selectedNotes,
                InstrumentType instrumentType,
                List<ScaleGroupingEntry> scaleGroupEntries,
                string selectedScale,
                StringBuilder sb)
            {
                GenerateAvailableKeysAndScalesSection(
                    selectedNotes,
                    instrumentType,
                    scaleGroupEntries,
                    sb,
                    selectedScale);
            }
        }

        private void GenerateAvailableKeysAndScalesSection(
            IEnumerable<Note> selectedNotes,
            InstrumentType instrumentType,
            List<ScaleGroupingEntry> scaleGroupingEntries,
            StringBuilder sb,
            string selectedScale)
        {
            var count = 0;

            while (count < scaleGroupingEntries.Count)
            {
                sb.Append("<tr>");

                if (scaleGroupingEntries.Count - count >= 2)
                {
                    AddLeftColumnCell(
                        selectedNotes,
                        instrumentType,
                        scaleGroupingEntries,
                        sb,
                        selectedScale,
                        count);

                    AddRightColumnCell(
                        selectedNotes,
                        instrumentType,
                        scaleGroupingEntries,
                        sb,
                        selectedScale,
                        count);

                    count += 2;
                }
                else
                {
                    AddLeftColumnCell(
                        selectedNotes,
                        instrumentType,
                        scaleGroupingEntries,
                        sb,
                        selectedScale,
                        count);

                    //No more Scale Groups
                    sb.Append($"<td></td>");
                    sb.Append($"<td></td>");

                    count++;
                }

                sb.Append("</tr>");
            }

            void AddLeftColumnCell(
                IEnumerable<Note> selectedNotes,
                InstrumentType instrumentType,
                List<ScaleGroupingEntry> scaleGroupingEntries,
                StringBuilder sb,
                string selectedScale,
                int count)
            {
                AddScalesToNoteSet(
                    selectedNotes,
                    instrumentType,
                    scaleGroupingEntries,
                    sb,
                    count,
                    isNeighbouringScaleGroup: false,
                    selectedScale);
            }

            void AddRightColumnCell(
                IEnumerable<Note> selectedNotes,
                InstrumentType instrumentType,
                List<ScaleGroupingEntry> scaleGroupingEntries,
                StringBuilder sb,
                string selectedScale,
                int count)
            {
                AddScalesToNoteSet(
                    selectedNotes,
                    instrumentType,
                    scaleGroupingEntries,
                    sb,
                    count,
                    isNeighbouringScaleGroup: true,
                    selectedScale);
            }
        }

        private void AddScalesToNoteSet(
            IEnumerable<Note> selectedNotes,
            InstrumentType instrumentType,
            List<ScaleGroupingEntry> scaleGroupingEntries,
            StringBuilder sb,
            int count,
            bool isNeighbouringScaleGroup,
            string selectedScale)
        {
            count = isNeighbouringScaleGroup ? count += 1 : count;

            sb.Append($"<td class=\"scaleResultCell\"><span class=\"scaleResultLabel\">{scaleGroupingEntries[count].NotesGroupingLabelHtml}</span></td>");

            sb.Append($"<td class=\"scaleResultCell\">");

            var scaleEntries = scaleGroupingEntries[count]
                .GroupedScales
                .Select(gs => new
                {
                    gs.ScaleLabel,
                    gs.FullName_Sharp,
                    gs.Popularity
                });

            var selectedNotesString = string.Join(",", selectedNotes.Select(s => $"'{s}'"));

            foreach (var availableScale in scaleEntries.GroupBy(s => s.Popularity))
            {
                sb.Append($"<span style=\"font-size:7px;\">{GetScalePopularityIcon(availableScale.First().Popularity).Item2}</span>");

                foreach (var scale in availableScale)
                {
                    var scaleText = $"<span>{scale.FullName_Sharp}</span>";

                    if (!scale.ScaleLabel.Equals(selectedScale))
                    {
                        var onclick = $"UpdateModel('/Instrument/UpdateFretboardModel'," +
                            $" '{scale.ScaleLabel}', null, [{selectedNotesString}], false, {Convert.ToInt32(instrumentType)})";

                        sb.Append($"<a class=\"scaleResult scaleText\" onclick=\"{onclick}\">{scaleText}</a>&nbsp;");
                    }
                    else
                    {
                        var onclick = $"UpdateModel('/Instrument/UpdateFretboardModel', null, null, [{selectedNotesString}], false, {Convert.ToInt32(instrumentType)})";
                        var style = "text-decoration: underline double; font-weight: bold;";

                        sb.Append($"<a class=\"scaleResult scaleText\" style=\"{style}\" onclick=\"{onclick}\">{scaleText}</a>&nbsp;");
                    }
                }

                sb.Append("<br/>");
            }

            sb.Append($"</td>");
        }

        public (string, string) GetScalePopularityIcon(int popularity)
        {
            switch (popularity)
            {
                case 0:
                    return ("Key", "🔑");
                case 1:
                    return ("Widely Used", "\U0001F7E2");
                case 2:
                    return ("Frequently Used", "\U0001F7E1");
                case 3:
                    return ("Rarely Used", "\U0001F7E0");
                case 4:
                    return ("Very Rarely Used", "\U0001F534");
                case 5:
                    return ("Super Rare", "\U0001F7E3");
                default:
                    return ("Unknown", $"{popularity}");
            }
        }

        public string GenerateNotesGroupingLabelHtml(IEnumerable<Note> selectedNotes, List<ScaleEntry> groupedScales)
        {
            if (groupedScales == null || !groupedScales.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            var firstScaleInGroup = groupedScales.FirstOrDefault();

            if (firstScaleInGroup != null)
            {
                var noteSet = firstScaleInGroup.Scale.NoteSet;

                sb.Append("<span class=\"scaleResultLabel\">");

                foreach (var note in noteSet)
                {
                    if (selectedNotes.Contains(note))
                    {
                        sb.Append($"<span class=\"scaleSetLabelNote matchedScaleSetLabelNote\">{_sharpNoteDictionary[note]}</span>");
                    }
                    else
                    {
                        sb.Append($"<span class=\"scaleSetLabelNote\">{_sharpNoteDictionary[note]}</span>");
                    }
                }

                sb.Append("</span>");
            }

            return sb.ToString();
        }

        public string GenerateNotesGroupingLabel(IEnumerable<Note> selectedNotes, List<ScaleEntry> groupedScales)
        {
            if (groupedScales == null || !groupedScales.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            var firstScaleInGroup = groupedScales.FirstOrDefault();

            if (firstScaleInGroup != null)
            {
                var noteSet = firstScaleInGroup.Scale.NoteSet;

                foreach (var note in noteSet)
                {
                    if (selectedNotes.Contains(note))
                    {
                        sb.Append($"({_sharpNoteDictionary[note]}) ");
                    }
                    else
                    {
                        sb.Append($"{_sharpNoteDictionary[note]} ");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public List<ScaleGroupingEntry> GenerateScaleGroupingList(
            IEnumerable<Note> selectedNotes,
            IEnumerable<ScaleEntry> scales,
            InstrumentType instrumentType,
            string selectedScale)
        {
            if (selectedNotes is null || selectedNotes?.Count() < 3)
            {
                return Enumerable.Empty<ScaleGroupingEntry>().ToList();
            }

            return GenerateScaleGroups(selectedNotes!, scales, selectedScale);
        }

        private List<ScaleGroupingEntry> GenerateScaleGroups(
            IEnumerable<Note> selectedNotes,
            IEnumerable<ScaleEntry> scales,
            string selectedScale)
        {
            var scaleGroupingEntries = new List<ScaleGroupingEntry>();
            var noteHashSets = GenerateNoteHashSets(scales);

            foreach (var scaleNotes in noteHashSets)
            {
                var allScales = scales
                    .Where(s => s.Scale.NoteSet.SetEquals(scaleNotes))
                    .OrderBy(s => s.Popularity)
                    .ToList();

                foreach (var scale in allScales)
                {
                    if (scale.FormalNameLabel_Sharp == selectedScale)
                    {
                        scale.Selected = true;
                    }
                }

                if (allScales.Any())
                {
                    var scaleLabel = GenerateNotesGroupingLabel(selectedNotes, allScales);

                    scaleGroupingEntries.Add(new ScaleGroupingEntry(allScales, scaleLabel));
                }
            }

            return scaleGroupingEntries;

            List<HashSet<Note>> GenerateNoteHashSets(IEnumerable<ScaleEntry> scales)
            {
                var distinctSets = new List<HashSet<Note>>();

                foreach (var scale in scales)
                {
                    if (!distinctSets.Where(ds => ds.SetEquals(scale.Scale.NoteSet)).Any())
                    {
                        distinctSets.Add(scale.Scale.NoteSet);
                    }
                }

                return distinctSets;
            }
        }
    }
}