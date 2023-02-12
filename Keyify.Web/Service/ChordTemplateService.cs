using Keyify.Models.ServiceModels;
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
            var result = new List<ChordTemplate>();

            if (notes != null)
            {
                var chordTemplates = _chordDefinitionService.ChordTemplates.Where(c => c.IsSubsetOf(notes)).ToList();

                result.AddRange(chordTemplates);
            }

            return result;
        }
    }
}
