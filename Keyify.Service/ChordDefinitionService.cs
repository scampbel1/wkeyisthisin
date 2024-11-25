using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Keyify.Service
{
    public class ChordDefinitionService : IChordDefinitionService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IChordDefinitionCache _chordDefinitionCache;
        private readonly IChordDefinitionRepository _chordDefinitionRepository;

        public ChordDefinitionService(
            IMemoryCache memoryCache,
            IChordDefinitionCache chordDefinitionCache,
            IChordDefinitionRepository chordDefinitionRepository)
        {
            _memoryCache = memoryCache;
            _chordDefinitionCache = chordDefinitionCache;
            _chordDefinitionRepository = chordDefinitionRepository;

            //Do not change this as it breaks unit tests
            //Task.WhenAny(InitialiseChordDefinitionCache());
        }

        public async Task<List<ChordDefinition>> FindChordDefinitions(Note[] notes)
        {
            var result = new List<ChordDefinition>();

            if (notes != null && _chordDefinitionCache.ChordDefinitions != null)
            {
                var chordDefinitionsCache = _chordDefinitionCache
                    .ChordDefinitions
                    .Where(c => c.IsSupersetOf(notes)).ToList();

                var chordDefinitions = await Task.FromResult(chordDefinitionsCache);

                result.AddRange(chordDefinitions);
            }

            return result;
        }        
    }
}
