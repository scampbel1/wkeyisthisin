using Keyify.Models.Service_Models;
using Keyify.Service.DataStores;
using Keyify.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Service
{
    public class ChordService : IChordService
    {
        private ChordDataStore _chordDefinitionService;

        public ChordService(ChordDataStore chordDefinitionService)
        {
            _chordDefinitionService = chordDefinitionService;
        }

        public List<ChordTemplate> FindChordWithNoteSequence(Note[] notes)
        {
            return _chordDefinitionService.Chords.Where(c => c == new ChordTemplate(notes)).ToList();
        }
    }
}
