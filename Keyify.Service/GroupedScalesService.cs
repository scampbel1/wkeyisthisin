using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using Keyify.Web.Service.Interfaces;

namespace Keyify.Web.Service
{
    public class GroupedScalesService : IGroupedScalesService
    {
        private readonly IChordDefinitionGroupingHtmlService _chordDefinitionGroupingHtmlService;

        private List<ScaleGroupingEntry> KeyGroupingEntries { get; init; } = new List<ScaleGroupingEntry>();
        private List<ScaleGroupingEntry> ScaleGroupingEntries { get; init; } = new List<ScaleGroupingEntry>();

        public List<ScaleGroupingEntry> GroupedScales => ScaleGroupingEntries;
        public List<ScaleGroupingEntry> GroupedKeys => KeyGroupingEntries;

        public int TotalScaleCount => ScaleGroupingEntries.Sum(s => s.Count);
        public int TotalKeyCount => KeyGroupingEntries.Sum(k => k.Count);

        public GroupedScalesService(IChordDefinitionGroupingHtmlService chordDefinitionGroupingHtmlService)
        {
            _chordDefinitionGroupingHtmlService = chordDefinitionGroupingHtmlService;
        }

        public void UpdateScaleGroupingModel(IEnumerable<ScaleEntry> scales, IEnumerable<Note> selectedNotes)
        {
            KeyGroupingEntries.Clear();
            ScaleGroupingEntries.Clear();

            var noteHashSets = GenerateNoteHashSets(scales);

            foreach (var scaleNotes in noteHashSets)
            {
                var allScales = scales.Where(s => s.Scale.NoteSet.SetEquals(scaleNotes)).ToList();
                var groupedKeys = allScales.Where(s => s.IsKey == true).ToList();
                var groupedScales = allScales.Where(s => s.IsKey == false).ToList();

                if (groupedScales.Any())
                {
                    var scalesHtmls = _chordDefinitionGroupingHtmlService.GenerateNotesGroupingLabelHtml(selectedNotes, groupedScales);

                    ScaleGroupingEntries.Add(new ScaleGroupingEntry(groupedScales, scalesHtmls));
                }

                if (groupedKeys.Any())
                {
                    var keysHtml = _chordDefinitionGroupingHtmlService.GenerateNotesGroupingLabelHtml(selectedNotes, groupedKeys);

                    KeyGroupingEntries.Add(new ScaleGroupingEntry(groupedKeys, keysHtml));
                }
            }
        }

        private IEnumerable<HashSet<Note>> GenerateNoteHashSets(IEnumerable<ScaleEntry> scales)
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
