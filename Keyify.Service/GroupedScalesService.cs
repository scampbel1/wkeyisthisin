using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using Keyify.Web.Service.Interfaces;
using Keyify.Web.Services.Interfaces;

namespace Keyify.Web.Service
{
    public class GroupedScalesService : IGroupedScalesService
    {
        private readonly IScaleGroupingHtmlService _scaleGroupingHtmlService;

        public GroupedScalesService(IScaleGroupingHtmlService scaleGroupingHtmlService)
        {
            _scaleGroupingHtmlService = scaleGroupingHtmlService;
        }

        private List<ScaleGroupingEntry> ScaleGroupingEntries { get; init; } = new List<ScaleGroupingEntry>();

        public List<ScaleGroupingEntry> GroupedScales => ScaleGroupingEntries;

        public int TotalScaleCount => ScaleGroupingEntries.Sum(s => s.Count);

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
                    var scalesHtmls = _scaleGroupingHtmlService.GenerateNotesGroupingLabelHtml(selectedNotes, allScales);

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
