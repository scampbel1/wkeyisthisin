using Keyify.Models.Service_Models;
using Keyify.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Keyify.Service
{
    public class ChordDefinitionService : IChordDefinitionService
    {
        private IEnumerable<ChordDefinition> _chordDefinitions;

        public ChordDefinitionService()
        {
            _chordDefinitions = GenerateChordDefinitions();
        }

        public IEnumerable<ChordDefinition> GetChordDefinitions()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ChordDefinition> GenerateChordDefinitions()
        {
            throw new NotImplementedException();
        }
    }
}
