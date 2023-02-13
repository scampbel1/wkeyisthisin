using Keyify.Models.Service;
using Keyify.Models.ServiceModels;
using Keyify.Service.Interfaces;
using Keyify.Web.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

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

        public IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes)
        {

            return _scaleService.FindScales(selectedNotes);
        }

        public IEnumerable<ChordDefinition> GetChordsDefinitions(Note[] selectedScaleNotes, Note[] selectedNotes)
        {
            var notes = selectedScaleNotes != null && selectedScaleNotes.Length >= selectedNotes.Length ? selectedScaleNotes : selectedNotes;

            return _chordDefinitionsSerice.FindChordDefinitions(notes);
        }
    }
}
