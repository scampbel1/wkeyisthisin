namespace Keyify.Services.Models
{
    public class ScaleGroupingEntry
    {
        public string NotesGroupingLabelHtml { get; init; }
        public List<ScaleEntry> GroupedScales { get; init; } = new List<ScaleEntry>();
        public int Count => GroupedScales.Count;

        public ScaleGroupingEntry(List<ScaleEntry> groupedScales, string notesGroupingLabelHtml)
        {
            GroupedScales = groupedScales;
            NotesGroupingLabelHtml = notesGroupingLabelHtml;
        }
    }
}
