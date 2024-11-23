using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Keyify.Infrastructure.Middleware
{
    public class CacheUpdateMiddleware : IMiddleware
    {
        private readonly ILogger<CacheUpdateMiddleware> _logger;
        private readonly IChordDefinitionRepository _chordDefinitionRepository;
        private readonly IScaleDefinitionRepository _scaleDefinitionRepository;
        private readonly IChordDefinitionCache _chordDefinitionCache;
        private readonly IScaleDefinitionCache _scaleDefinitionCache;

        public CacheUpdateMiddleware(ILogger<CacheUpdateMiddleware> logger,
            IChordDefinitionRepository chordDefinitionRepository,
            IScaleDefinitionRepository scaleDefinitionRepository,
            IChordDefinitionCache chordDefinitionCache,
            IScaleDefinitionCache scaleDefinitionCache)
        {
            _logger = logger;
            _chordDefinitionRepository = chordDefinitionRepository;
            _scaleDefinitionRepository = scaleDefinitionRepository;
            _chordDefinitionCache = chordDefinitionCache;
            _scaleDefinitionCache = scaleDefinitionCache;
        }

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
                _logger.Log(LogLevel.Information, "No Scale Definitions found in Cache. Initialising from database.");

                var scaleDefinitions = await _scaleDefinitionRepository.GetAllScaleDefinitions();

                await _scaleDefinitionCache.Initialise(scaleDefinitions);
            }
        }

        private async Task CheckChordCache()
        {
            if (!_chordDefinitionCache.ChordDefinitions!.Any())
            {
                _logger.Log(LogLevel.Information, "No Chord Definitions found in Cache. Initialising from database.");

                var chordDefinitions = await _chordDefinitionRepository.GetAllChordDefinitions();

                await _chordDefinitionCache.Initialise(chordDefinitions);
            }
        }
    }
}
