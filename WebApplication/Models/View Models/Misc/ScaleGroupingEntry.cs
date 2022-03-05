using Keyify.Models.Service;
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

        public ScaleGroupingEntry(List<ScaleEntry> groupedScales, IEnumerable<string> selectedNotes = null)
        {
            NotesGroupingLabel = groupedScales.FirstOrDefault().NoteSetLabel_Sharp;
            GroupedScales = groupedScales;
            NotesGroupingLabelHtml = GenerateNotesGroupingLabelHtml(selectedNotes);
        }

        private string GenerateNotesGroupingLabelHtml(IEnumerable<string> selectedNotes = null)
        {
            var sb = new StringBuilder();

            sb.Append("<span class=\"scaleResultLabel\">");

            foreach (var note_sharp in GroupedScales.FirstOrDefault().Scale.Notes_Sharp)
            {
                if (selectedNotes.Contains(note_sharp))
                {
                    sb.Append($"<span class=\"matchedNoteScaleSetLabel\">{note_sharp}</span>");
                }
                else
                {
                    sb.Append($"<span>{note_sharp}</span>");
                }
            }

            sb.Append("</span>");

            return sb.ToString();
        }
    }
}
