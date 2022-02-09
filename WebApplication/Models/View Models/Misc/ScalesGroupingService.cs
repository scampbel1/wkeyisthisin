using Keyify.Models.Interfaces;
using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Models.View_Models.Misc
{
    public class ScalesGroupingService : IScalesGroupingService
    {
        private List<ScaleGroupingEntry> ScaleGroupingEntries { get; init; } = new List<ScaleGroupingEntry>();

        public List<ScaleGroupingEntry> GetGroupedScales()
        {
            return ScaleGroupingEntries;
        }

        public int GetTotalScaleCount()
        {
            return ScaleGroupingEntries.Sum(s => s.Count);
        }

        public void UpdateScaleGroupingModel(List<ScaleEntry> scales)
        {
            ScaleGroupingEntries.Clear();

            var noteHashSets = GenerateNoteHashSets(scales);

            foreach (var scaleNotes in noteHashSets)
            {
                var groupedScales = scales.Where(s => s.Scale.NoteSet.SetEquals(scaleNotes)).ToList();

                ScaleGroupingEntries.Add(new ScaleGroupingEntry(string.Join(',', scaleNotes), groupedScales));
            }
        }

        private List<HashSet<Note>> GenerateNoteHashSets(List<ScaleEntry> scales)
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
