using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keyify.Models.View_Models.Misc
{
    public class ScaleGroupingEntry
    {
        public string NotesGroupingLabel { get; init; }
        public string NotesGroupingLabelHtml { get; init; }
        public List<ScaleEntry> GroupedScales { get; init; } = new List<ScaleEntry>();
        public int Count => GroupedScales.Count;

        public ScaleGroupingEntry(List<ScaleEntry> groupedScales, IEnumerable<Note> selectedNotes)
        {
            NotesGroupingLabel = groupedScales.FirstOrDefault().NoteSetLabel_Sharp;
            GroupedScales = groupedScales;
            NotesGroupingLabelHtml = GenerateNotesGroupingLabelHtml(selectedNotes);
        }

        private string GenerateNotesGroupingLabelHtml(IEnumerable<Note> selectedNotes)
        {
            var sb = new StringBuilder();

            sb.Append("<span class=\"scaleResultLabel\">");

            foreach (var note in GroupedScales.FirstOrDefault().Scale.NoteSet)
            {
                if (selectedNotes.Contains(note))
                {
                    sb.Append($"<span class=\"scaleSetLabelNote matchedScaleSetLabelNote\">{NoteHelper.ConvertNoteToStringEquivalent(note, true)}</span>");
                }
                else
                {
                    sb.Append($"<span class=\"scaleSetLabelNote\">{NoteHelper.ConvertNoteToStringEquivalent(note, true)}</span>");
                }
            }

            sb.Append("</span>");

            return sb.ToString();
        }
    }
}
