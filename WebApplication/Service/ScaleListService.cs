using Keyify.Service.Interface;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Models.Service
{
    public partial class ScaleListService : IScaleListService
    {
        private readonly IModeDefinitionService _scaleDirectoryService;
        private readonly List<ScaleEntry> _scaleList;

        public ScaleListService(IModeDefinitionService scaleDirectoryService)
        {
            _scaleDirectoryService = scaleDirectoryService;
            _scaleList = GenerateScaleList();
        }

        public List<ScaleEntry> GetScaleList()
        {
            return _scaleList;
        }

        public IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes)
        {
            return _scaleList.Where(a => a.Scale.NoteSet.IsSupersetOf(selectedNotes));
        }

        public List<ScaleEntry> GenerateScaleList()
        {
            return GetScaleEntries(_scaleDirectoryService.Modes);
        }
    }
}