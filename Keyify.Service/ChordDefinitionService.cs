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
                List<ChordDefinition> chordDefinitions;

                _memoryCache.TryGetValue(CacheKey, out chordDefinitions!);

                result = chordDefinitions?.Where(c => c.IsSupersetOf(notes)).ToList();
            }

            return await Task.FromResult(result ?? Enumerable.Empty<ChordDefinition>().ToList());
        }
    }
}
