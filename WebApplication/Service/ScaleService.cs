using Keyify.Service.Interface;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Models.Service
{
    public partial class ScaleService : IScaleService
    {
        private readonly IModeService _modeService;
        private readonly List<ScaleEntry> _scaleList;

        public List<ScaleEntry> Scales => _scaleList;

        public ScaleService(IModeService modeService)
        {
            _modeService = modeService;
            _scaleList = GenerateScaleList();
        }

        public IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes)
        {
            return _scaleList.Where(a => a.Scale.NoteSet.IsSupersetOf(selectedNotes));
        }

        private List<ScaleEntry> GenerateScaleList()
        {
            return GetScaleEntries(_modeService.Modes);
        }
    }
}