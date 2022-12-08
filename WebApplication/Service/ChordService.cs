﻿using Keyify.Enums;
using Keyify.Models.Service_Models;
using Keyify.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Service
{
    public class ChordService : IChordService
    {
        private ChordDataStore _chordDefinitionService;

        public ChordService(ChordDataStore chordDefinitionService)
        {
            _chordDefinitionService = chordDefinitionService;
        }

        public List<ChordDefinition> FindChordWithNoteSequence(Note[] notes)
        {
            return new List<ChordDefinition>() { new ChordDefinition(ChordType.Major, new Note[] { Note.F, Note.A, Note.C }) };

            //return _chordDefinitionService.Chords.Where(c => c.Notes == notes).ToList();
        }
    }
}