using Keyify.Models.Service;
using System.Collections.Generic;

namespace Keyify.Models.View_Models.Misc
{
    public class ScaleGroupingEntry
    {
        public string NotesGroupingLabel { get; init; }
        public List<ScaleEntry> GroupedScales { get; init; } = new List<ScaleEntry>();
        public int Count => GroupedScales.Count;

        public ScaleGroupingEntry(string notesGroupingLabel, List<ScaleEntry> groupedScales)
        {
            NotesGroupingLabel = notesGroupingLabel;
            GroupedScales = groupedScales;
        }
    }
}
