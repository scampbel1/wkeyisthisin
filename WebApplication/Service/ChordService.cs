using Keyify.Models.Service_Models;
using Keyify.Service.Interfaces;
using System.Collections.Generic;

namespace Keyify.Service
{
    public class ChordService : IChordService
    {
        private ChordDefinitionService _chordDefinitionService;

        public List<ChordDefinition> Chords => _chordDefinitionService.Chords;

        public ChordService(ChordDefinitionService chordDefinitionService)
        {
            _chordDefinitionService = chordDefinitionService;
        }
    }
}
