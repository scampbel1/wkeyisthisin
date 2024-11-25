using Keyify.Infrastructure.Caches.Interfaces;
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
        IChordDefinitionRepository chordDefinitionRepository,
        IScaleDefinitionRepository scaleDefinitionRepository,
        IScaleDefinitionCache scaleDefinitionCache,
        IMemoryCache memoryCache,
        INoteFormatService noteFormatService) : IMiddleware
    {
        private readonly IChordDefinitionRepository _chordDefinitionRepository = chordDefinitionRepository;
        private readonly IScaleDefinitionRepository _scaleDefinitionRepository = scaleDefinitionRepository;
        private readonly IScaleDefinitionCache _scaleDefinitionCache = scaleDefinitionCache;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly INoteFormatService _noteFormatService = noteFormatService;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await CheckScaleCache();
            await CheckChordCache();

            await next(context);
        }

        private async Task CheckScaleCache()
        {
            if (!_scaleDefinitionCache.ScaleDefinitions.Any())
            {
                var scaleDefinitions = await _scaleDefinitionRepository.GetAllScaleDefinitions();

                await _scaleDefinitionCache.Initialise(scaleDefinitions);
            }
        }

        private async Task CheckChordCache()
        {
            var cacheKey = "ChordDefinitions";
            if (!_memoryCache.TryGetValue(cacheKey, out List<ChordDefinition> chordDefinitions))
            {
                var chordDefinitionsEntities = await _chordDefinitionRepository.GetAllChordDefinitions();
                chordDefinitions = await GenerateChordDefinitions(chordDefinitionsEntities);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(1));
                _memoryCache.Set(cacheKey, chordDefinitions, cacheEntryOptions);
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
                var notes = await GenerateChordDefinitionNotes(currentNote, chordDefinitionEntity.Intervals);
                var sharpNote = _noteFormatService.SharpNoteDictionary[notes[0]];

                chordDefinitions.Add(new ChordDefinition(
                    chordType: chordDefinitionEntity.Name ?? "Name not found!",
                    notes,
                    rootNote: sharpNote,
                    chordDefinitionEntity.Popularity));

                currentNote++;
            }
        }

        private static async Task<Note[]> GenerateChordDefinitionNotes(Note rootNote, Interval[] intervals)
        {
            var count = 0;
            var currentNote = rootNote;
            var chordNotes = new Note[intervals.Length];

            foreach (var interval in intervals)
            {
                currentNote = interval == Interval.R ? currentNote : await FindNextNote(currentNote, interval);
                chordNotes[count] = currentNote;
                count++;
            }

            return chordNotes;
        }

        private static async Task<Note> FindNextNote(Note currentNote, Interval interval)
        {
            var nextStepIndex = (int)currentNote + (int)interval;

            var result = nextStepIndex > (int)Note.Ab
                ? (Note)(nextStepIndex - (int)Note.Ab) - 1
                : (Note)nextStepIndex;

            return await Task.FromResult(result);
        }
    }
}