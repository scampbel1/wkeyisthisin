using Keyify.Models.Service_Models;
using Keyify.Service.Caches;
using Keyify.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Service
{
    public class ChordTemplateService : IChordTemplateService
    {
        private ChordTemplateDataCache _chordDefinitionService;

        public ChordTemplateService(ChordTemplateDataCache chordDefinitionService)
        {
            _chordDefinitionService = chordDefinitionService;
        }

        public List<ChordTemplate> FindChordTemplates(Note[] notes)
        {
            var chordDefinitions = _chordDefinitionService.ChordTemplates.Where(c => c.IsSubsetOf(notes)).ToList();

            return chordDefinitions;
        }
    }
}
