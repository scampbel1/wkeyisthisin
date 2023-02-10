﻿using Keyify.Models.Service;
using Keyify.Models.View_Models.Misc;
using KeyifyClassLibrary.Enums;
using KeyifyWebClient.Models.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace KeyifyWebClient.Models.ViewModels
{
    //WARNING: Be careful renaming this class! (It may not rename the reference in the Views)
    public partial class InstrumentViewModel
    {
        public string ViewTitle = $"What Key Is This In?";

        public int TotalKeyCount { get; set; }
        public int TotalScaleCount { get; set; }
        public bool IsSelectionLocked { get; set; }

        public Fretboard Fretboard { get; set; }
        public ScaleEntry SelectedScale { get; set; }
        public List<ScaleEntry> Scales { get; set; } = new List<ScaleEntry>();
        private List<FretboardNote> NotesMatrix { get; } = new List<FretboardNote>();

        public InstrumentViewModel(Fretboard fretboard)
        {
            Fretboard = fretboard;
            NotesMatrix = InitialiseNotesMatrix();
        }

        public void UpdateViewModel(Fretboard fretboard) => Fretboard = fretboard;
        public string SelectedNotesJson => JsonSerializer.Serialize(SelectedNotes.Select(n => n.Note.ToString()));
        public string AvailableKeysAndScalesLabel => $"{GetAvailableKeysLabel()} {GetAvailableScaleLabel()}";
        public string AvailableKeysAndScalesTableHtml => GenerateAvailableKeysAndScalesTable(AvailableKeyGroups, AvailableScaleGroups);

        public List<FretboardNote> SelectedNotes => NotesMatrix.Where(n => n.Selected).ToList();
        public List<FretboardNote> UnselectedNotes => NotesMatrix.Where(n => !n.Selected).ToList();
        public List<FretboardNote> NotesPartOfScale => NotesMatrix.Where(n => n.InSelectedScale).ToList();

        public List<ScaleGroupingEntry> AvailableKeyGroups { get; set; } = new List<ScaleGroupingEntry>();
        public List<ScaleGroupingEntry> AvailableScaleGroups { get; set; } = new List<ScaleGroupingEntry>();

        private List<FretboardNote> InitialiseNotesMatrix()
        {
            var fretboardNotes = new List<FretboardNote>((int)Note.Ab);

            foreach (Note note in Enum.GetValues(typeof(Note)))
            {
                fretboardNotes.Add(new FretboardNote(note));
            }

            return fretboardNotes;
        }

        private string GetAvailableKeysLabel()
        {
            var matchingScaleCount = TotalKeyCount;

            switch (matchingScaleCount)
            {
                case 0:
                    return GetNoKeysFoundMessage();
                case 1:
                    return $"{matchingScaleCount} Matching Key";
                default:
                    return $"{matchingScaleCount} Matching Keys";
            }
        }

        private string GetNoKeysFoundMessage()
        {
            var selectedNoteCount = SelectedNotes.Count;

            if (selectedNoteCount <= 2)
                return $"";

            if (selectedNoteCount > 2)
                return "No Matching Keys";
            else
                return "";
        }

        private string GetAvailableScaleLabel()
        {
            var matchingScaleCount = TotalScaleCount;

            switch (matchingScaleCount)
            {
                case 0:
                    return GetNoScalesFoundMessage();
                case 1:
                    return $"{matchingScaleCount} Matching Scale";
                default:
                    return $"{matchingScaleCount} Matching Scales";
            }
        }

        private string GetNoScalesFoundMessage()
        {
            var selectedNoteCount = SelectedNotes.Count;

            if (selectedNoteCount == 1)
                return $"Only {selectedNoteCount} Note Selected";
            else if (selectedNoteCount <= 2)
                return $"Only {selectedNoteCount} Notes Selected";

            if (selectedNoteCount > 2)
                return "No Matching Scales";
            else
                return "No Notes Selected";
        }

        private string GenerateAvailableKeysAndScalesTable(List<ScaleGroupingEntry> availableKeyGroups, List<ScaleGroupingEntry> availableScaleGroups)
        {
            if (!availableKeyGroups.Any() && !availableScaleGroups.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.Append("<table class=\"scaleTable\">");

            GenerateAvailableKeysAndScalesSection(availableKeyGroups, sb);
            GenerateAvailableKeysAndScalesSection(availableScaleGroups, sb);

            sb.Append("</table>");

            return sb.ToString();
        }

        private void GenerateAvailableKeysAndScalesSection(List<ScaleGroupingEntry> scaleGroupingEntries, StringBuilder sb)
        {
            var count = 0;

            while (count < scaleGroupingEntries.Count())
            {
                sb.Append("<tr>");

                if (scaleGroupingEntries.Count() - count >= 2)
                {
                    AddScalesToNoteSet(scaleGroupingEntries, sb, count, false);
                    AddScalesToNoteSet(scaleGroupingEntries, sb, count, true);

                    count += 2;
                }
                else
                {
                    AddScalesToNoteSet(scaleGroupingEntries, sb, count, false);

                    //No more Scale Groups
                    sb.Append($"<td></td>");
                    sb.Append($"<td></td>");

                    count++;
                }

                sb.Append("</tr>");
            }

            //Blank Row to separate Keys and Scales
            sb.Append("<tr class=\"keyAndScaleSeparator\">");
            sb.Append($"<td></td>");
            sb.Append($"<td></td>");
            sb.Append($"<td></td>");
            sb.Append($"<td></td>");
            sb.Append("</tr>");
        }

        private void AddScalesToNoteSet(List<ScaleGroupingEntry> scaleGroupingEntries, StringBuilder sb, int count, bool isNeighbouringScaleGroup)
        {
            count = isNeighbouringScaleGroup ? count += 1 : count;

            sb.Append($"<td class=\"scaleResultLabelColumn\"><span class=\"scaleResultLabel\">{scaleGroupingEntries[count].NotesGroupingLabelHtml}</span></td>");

            sb.Append($"<td class=\"scaleResultColumn\">");

            foreach (var availableScale in scaleGroupingEntries[count].GroupedScales.Select(gs => new KeyValuePair<string, string>(gs.ScaleLabel, gs.ColloquialismIncludingFormalName_Sharp)))
            {
                sb.Append($"<a class=\"scaleResult scaleText\" onclick=\"UpdateModel('/{Fretboard.InstrumentType.ToString()}/UpdateFretboardModel', '{availableScale.Key}', null, {$"[{string.Join(',', SelectedNotes.Select(s => $"'{s.Note}'"))}]"} )\">{availableScale.Value}</a>&nbsp;");
            }

            sb.Append($"</td>");
        }
    }
}