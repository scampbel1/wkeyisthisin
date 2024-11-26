using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Keyify.Service
{
    public class ChordDefinitionService(
        IMemoryCache memoryCache,
        IChordDefinitionRepository chordDefinitionRepository) : IChordDefinitionService
    {
        private const string CacheKey = "ChordDefinitions";
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly IChordDefinitionRepository _chordDefinitionRepository = chordDefinitionRepository;

        public async Task<List<ChordDefinition>> FindChordDefinitions(Note[] notes)
        {
            var result = new List<ChordDefinition>();

            if (notes != null)
            {
                _memoryCache.TryGetValue(CacheKey, out List<ChordDefinition> chordDefinitions);

                //            var chordDefinitionsCache = _chordDefinitionCache
                //.ChordDefinitions
                //.Where(c => c.IsSupersetOf(notes)).ToList();

                //var chordDefinitions = await Task.FromResult(chordDefinitionsCache);

                result = chordDefinitions?.Where(c => c.IsSupersetOf(notes)).ToList();
            }

            return await Task.FromResult(result ?? Enumerable.Empty<ChordDefinition>().ToList());
        }
    }
}
