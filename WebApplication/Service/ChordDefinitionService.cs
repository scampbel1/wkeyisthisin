using Keyify.Models.Service_Models;
using System.Collections.Generic;

namespace Keyify.Service
{
    public class ChordDefinitionService
    {
        public List<ChordDefinition> Chords => GenerateChordDefinitions();

        private List<ChordDefinition> GenerateChordDefinitions()
        {
            var chordDefinitions = new List<ChordDefinition>();

            return chordDefinitions;
        }
    }
}
