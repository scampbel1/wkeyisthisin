using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;

namespace Keyify.Models.Service
{
    public class ScaleService : IScaleService
    {
        private readonly IModeService _modeService;
        private readonly List<ScaleEntry> _scaleList;

        public List<ScaleEntry> Scales => _scaleList;

        public ScaleService(IModeService modeService)
        {
            _modeService = modeService;
            _scaleList = GenerateScaleList();
        }

        public async Task<IEnumerable<ScaleEntry>> FindScales(IEnumerable<Note> selectedNotes)
        {
            return _scaleList.Where(a => a.Scale.NoteSet.IsSupersetOf(selectedNotes));
        }

        private List<ScaleEntry> GenerateScaleList()
        {
            return GetScaleEntries(_modeService.Modes);
        }

        private List<ScaleEntry> GetScaleEntries(IEnumerable<ModeDefinition> modeDefinitionDictionary)
        {
            var scaleEntries = new List<ScaleEntry>();

            foreach (var modeDefinition in modeDefinitionDictionary)
            {
                scaleEntries.AddRange(GenerateScaleEntries(modeDefinition));
            }

            return scaleEntries;
        }

        private List<ScaleEntry> GenerateScaleEntries(ModeDefinition modeDefinition)
        {
            var scaleEntry = new List<ScaleEntry>();

            if (modeDefinition.ExplicitNotesForMode != null)
            {
                scaleEntry.AddRange(from Note note in modeDefinition.ExplicitNotesForMode
                                    let scale = new GeneratedScale(note, modeDefinition)
                                    select new ScaleEntry(scale));
            }

            return scaleEntry;
        }
    }
}