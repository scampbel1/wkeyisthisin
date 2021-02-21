using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Service
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

        public IEnumerable<ScaleEntry> GenerateScaleList()
        {
            return GetScaleEntries(_scaleDirectoryService.GetModeDefinitions());
        }       
    }
}