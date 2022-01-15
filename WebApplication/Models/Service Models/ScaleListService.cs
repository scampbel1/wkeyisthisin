using Keyify.Service.Interface;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Models.Service
{
    public partial class ScaleListService : IScaleListService
    {
        private readonly IModeDefinitionService _scaleDirectoryService;
        private readonly IEnumerable<ScaleEntry> _scaleList;

        public ScaleListService(IModeDefinitionService scaleDirectoryService)
        {
            _scaleDirectoryService = scaleDirectoryService;
            _scaleList = GenerateScaleList();
        }

        public IEnumerable<ScaleEntry> GetScaleList()
        {
            return _scaleList;
        }

        public IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes)
        {
            return _scaleList.Where(a => a.Scale.NoteSet.IsSupersetOf(selectedNotes));
        }

        public Dictionary<HashSet<Note>, List<ScaleEntry>> FindScalesSortByNoteSet(IEnumerable<Note> selectedNotes)
        {
            var scales = FindScales(selectedNotes);

            var sortedScales = new Dictionary<HashSet<Note>, List<ScaleEntry>>();

            foreach (var noteSet in scales.Select(s => s.Scale).Distinct())
            {
                sortedScales.Add(noteSet.NoteSet, scales.Where(s => s.Scale.NoteSet.SetEquals(noteSet.Notes)).ToList());
            }

            return sortedScales;
        }

        public IEnumerable<ScaleEntry> GenerateScaleList()
        {
            return GetScaleEntries(_scaleDirectoryService.GetModeDefinitions());
        }
    }
}