using Keyify.MusicTheory.Enums;
using System.Text;

namespace Keyify.Services.Models
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

        //TODO - Move this to a HTML Service
        private string GenerateNotesGroupingLabelHtml(IEnumerable<Note> selectedNotes)
        {
            var sb = new StringBuilder();

            sb.Append("<span class=\"scaleResultLabel\">");
            //Convert {NoteHelper.ConvertNoteToStringEquivalent(note, true)}
            foreach (var note in GroupedScales.FirstOrDefault().Scale.NoteSet)
            {
                if (selectedNotes.Contains(note))
                {
                    sb.Append($"<span class=\"scaleSetLabelNote matchedScaleSetLabelNote\">{note}</span>");
                }
                else
                {
                    sb.Append($"<span class=\"scaleSetLabelNote\">{note}</span>");
                }
            }

            sb.Append("</span>");

            return sb.ToString();
        }
    }
}
