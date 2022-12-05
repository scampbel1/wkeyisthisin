using Keyify.Models.Service_Models;
using Keyify.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Keyify.Service
{
    public class ChordDefinitionService : IChordDefinitionService
    {
        public List<ChordDefinition> Chords => throw new NotImplementedException();

        public ChordDefinitionService()
        {
            //_chordDefinitions = GenerateChordDefinitions();
        }
    }
}
