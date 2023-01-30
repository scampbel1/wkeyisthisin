using Keyify.Models.Interfaces;
using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Models.View_Models.Misc
{
    public class ScalesGroupingService : IScalesGroupingService
    {
        private List<ScaleGroupingEntry> KeyGroupingEntries { get; init; } = new List<ScaleGroupingEntry>();
        private List<ScaleGroupingEntry> ScaleGroupingEntries { get; init; } = new List<ScaleGroupingEntry>();

        public List<ScaleGroupingEntry> GroupedScales => ScaleGroupingEntries;
        public List<ScaleGroupingEntry> GroupedKeys => KeyGroupingEntries;
        public int TotalScaleCount => ScaleGroupingEntries.Sum(s => s.Count);
        public int TotalKeyCount => KeyGroupingEntries.Sum(k => k.Count);

        public void UpdateScaleGroupingModel(List<ScaleEntry> scales, IEnumerable<string> selectedNotes)
        {
            ScaleGroupingEntries.Clear();

            var noteHashSets = GenerateNoteHashSets(scales);

            var sharpNotes = ConvertSelectedNotesToSharpNotes(selectedNotes);

            foreach (var scaleNotes in noteHashSets)
            {
                var allScales = scales.Where(s => s.Scale.NoteSet.SetEquals(scaleNotes)).ToList();
                var groupedScales = allScales.Where(s => s.IsKey == false).ToList();
                var groupedKeys = allScales.Where(s => s.IsKey == true).ToList();

                if (groupedScales.Any())
                {
                    ScaleGroupingEntries.Add(new ScaleGroupingEntry(groupedScales, sharpNotes));
                }

                if (groupedKeys.Any())
                {
                    KeyGroupingEntries.Add(new ScaleGroupingEntry(groupedKeys, sharpNotes));
                }
            }
        }

        private IEnumerable<string> ConvertSelectedNotesToSharpNotes(IEnumerable<string> selectedNotes)
        {
            var sharpNotes = new List<string>();

            var notes = NoteHelper.ConvertNoteStringArrayIntoNotes(selectedNotes.ToArray());

            foreach (var note in notes)
            {
                sharpNotes.Add(NoteHelper.ConvertNoteToStringEquivalent(note, true));
            }

            return sharpNotes;
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
