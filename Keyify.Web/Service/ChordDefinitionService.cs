using Keyify.Models.ServiceModels;
using Keyify.Service.Caches;
using Keyify.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Service
{
    public class ChordDefinitionService : IChordDefinitionService
    {
        private ChordDefinitionDataCache _chordDefinitionService;

        public ChordDefinitionService(ChordDefinitionDataCache chordDefinitionService)
        {
            _chordDefinitionService = chordDefinitionService;
        }

        public List<ChordDefinition> FindChordDefinitions(Note[] notes)
        {
            var result = new List<ChordDefinition>();

            if (notes != null)
            {
                var chordDefinitions = _chordDefinitionService.ChordDefintions.Where(c => c.IsSubsetOf(notes)).ToList();

                result.AddRange(chordDefinitions);
            }

            return result;
        }
    }
}
