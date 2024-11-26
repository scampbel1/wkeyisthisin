using Keyify.Infrastructure.Caches;
using Keyify.Infrastructure.Models.ScaleDefinition;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Models;
using Keyify.Web.Infrastructure.Models.ChordDefinition;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace Keyify.Infrastructure.Middleware
{
    public class ChordScaleCacheMiddleware(
        IMemoryCache memoryCache,
        INoteFormatService noteFormatService,
        IChordDefinitionRepository chordDefinitionRepository,
        IScaleDefinitionRepository scaleDefinitionRepository,
        CacheSignal<ScaleDefinition> scaleDefinitionCacheSignal,
        CacheSignal<ChordDefinition> chordDefinitionCacheSignal) : IMiddleware
    {
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly INoteFormatService _noteFormatService = noteFormatService;
        private readonly IChordDefinitionRepository _chordDefinitionRepository = chordDefinitionRepository;
        private readonly IScaleDefinitionRepository _scaleDefinitionRepository = scaleDefinitionRepository;
        private readonly CacheSignal<ScaleDefinition> _scaleDefinitionCacheSignal = scaleDefinitionCacheSignal;
        private readonly CacheSignal<ChordDefinition> _chordDefinitionCacheSignal = chordDefinitionCacheSignal;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await CheckScaleCache();
            await CheckChordCache();

            await next(context);
        }

        private async Task CheckScaleCache()
        {
            var cacheKey = "ScaleDefinitions";

            List<ScaleDefinition> scaleDefinitions;

            if (!_memoryCache.TryGetValue(cacheKey, out scaleDefinitions!))
            {
                try
                {
                    await _scaleDefinitionCacheSignal.WaitAsync();

                    var scaleDefinitionEntities = await _scaleDefinitionRepository.GetAllScaleDefinitions();

                    scaleDefinitions = new List<ScaleDefinition>(scaleDefinitionEntities.Count);

                    ConvertScaleDefinitionEntities(scaleDefinitions!, scaleDefinitionEntities);

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromHours(1));

                    _memoryCache.Set(cacheKey, scaleDefinitions, cacheEntryOptions);
                }
                finally
                {
                    _scaleDefinitionCacheSignal.Release();
                }
            }
        }

        private void ConvertScaleDefinitionEntities(List<ScaleDefinition> scaleDefinitions, List<ScaleDefinitionEntity> scaleDefinitionEntities)
        {
            if (scaleDefinitionEntities is null)
            {
                return;
            }

            foreach (var entity in scaleDefinitionEntities)
            {
                var scaleEntry = new ScaleDefinition(
                    entity.Name!,
                    entity.Intervals!,
                    entity.Degrees!,
                    entity.Description!,
                    entity.AllowedRootNotes,
                    entity.Popularity);

                scaleDefinitions.Add(scaleEntry);
            }
        }

        private async Task CheckChordCache()
        {
            var cacheKey = "ChordDefinitions";

            List<ChordDefinition> chordDefinitions;

            if (!_memoryCache.TryGetValue(cacheKey, out chordDefinitions!))
            {
                try
                {
                    await _scaleDefinitionCacheSignal.WaitAsync();

                    var chordDefinitionEntities = await _chordDefinitionRepository.GetAllChordDefinitions();

                    chordDefinitions = await GenerateChordDefinitions(chordDefinitionEntities);

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromHours(1));

                    _memoryCache.Set(cacheKey, chordDefinitions, cacheEntryOptions);
                }
                finally
                {
                    _scaleDefinitionCacheSignal.Release();
                }
            }
        }

        private async Task<List<ChordDefinition>> GenerateChordDefinitions(List<ChordDefinitionEntity> chordDefinitionEntities)
        {
            var result = new List<ChordDefinition>();

            foreach (var chordDefinitionEntity in chordDefinitionEntities)
            {
                await GenerateChordDefinitionByChordType(chordDefinitionEntity, result);
            }

            return result;
        }

        private async Task GenerateChordDefinitionByChordType(ChordDefinitionEntity chordDefinitionEntity, List<ChordDefinition> chordDefinitions)
        {
            if (chordDefinitionEntity is null || chordDefinitionEntity.Intervals is null)
            {
                return;
            }

            var currentNote = Note.A;

            while (currentNote <= Note.Ab)
            {
                var notes = await ChordScaleCacheMiddlewareHelpers.GenerateChordDefinitionNotes(currentNote, chordDefinitionEntity.Intervals);
                var sharpNote = _noteFormatService.SharpNoteDictionary[notes[0]];

                chordDefinitions.Add(new ChordDefinition(
                    chordType: chordDefinitionEntity.Name ?? "Name not found!",
                    notes,
                    rootNote: sharpNote,
                    chordDefinitionEntity.Popularity));

                currentNote++;
            }
        }
    }
}