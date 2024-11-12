using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using Keyify.Web.Service.Interfaces;

namespace Keyify.Web.Service
{
    public class GroupedScalesService : IGroupedScalesService
    {
        private readonly IChordDefinitionGroupingHtmlService _chordDefinitionGroupingHtmlService;

        private List<ScaleGroupingEntry> ScaleGroupingEntries { get; init; } = new List<ScaleGroupingEntry>();

        public List<ScaleGroupingEntry> GroupedScales => ScaleGroupingEntries;

        public int TotalScaleCount => ScaleGroupingEntries.Sum(s => s.Count);

        public GroupedScalesService(IChordDefinitionGroupingHtmlService chordDefinitionGroupingHtmlService)
        {
            _chordDefinitionGroupingHtmlService = chordDefinitionGroupingHtmlService;
        }

        public void UpdateScaleGroupingModel(IEnumerable<ScaleEntry> scales, IEnumerable<Note> selectedNotes)
        {
            ScaleGroupingEntries.Clear();

            var noteHashSets = GenerateNoteHashSets(scales);

            foreach (var scaleNotes in noteHashSets)
            {
                var allScales = scales
                    .Where(s => s.Scale.NoteSet.SetEquals(scaleNotes))
                    .OrderBy(s => s.Popularity)
                    .ToList();

                if (allScales.Any())
                {
                    var scalesHtmls = _chordDefinitionGroupingHtmlService.GenerateNotesGroupingLabelHtml(selectedNotes, allScales);

                    ScaleGroupingEntries.Add(new ScaleGroupingEntry(allScales, scalesHtmls));
                }
            }
        }

        private List<HashSet<Note>> GenerateNoteHashSets(IEnumerable<ScaleEntry> scales)
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
