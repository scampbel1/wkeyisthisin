using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using Keyify.Web.Services.Interfaces;

namespace Keyify.Web.Service
{
    public class MusicTheoryService : IMusicTheoryService
    {
        private readonly IScaleService _scaleService;
        private readonly IChordDefinitionService _chordDefinitionsSerice;

        public MusicTheoryService(IScaleService scaleService, IChordDefinitionService chordDefinitionService)
        {
            _scaleService = scaleService;
            _chordDefinitionsSerice = chordDefinitionService;
        }

        public async Task<IEnumerable<ScaleEntry>> FindScales(IEnumerable<Note> selectedNotes)
        {
            return await _scaleService.FindScales(selectedNotes);
        }

        public async Task <IEnumerable<ChordDefinition>> GetChordsDefinitions(Note[] selectedScaleNotes, Note[] selectedNotes)
        {
            var notes = selectedScaleNotes != null && selectedScaleNotes.Length >= selectedNotes.Length ? selectedScaleNotes : selectedNotes;

            return await _chordDefinitionsSerice.FindChordDefinitions(notes);
        }
    }
}
