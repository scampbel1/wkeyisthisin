using Keyify.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Keyify.Infrastructure.Middleware
{
    public class ChordScaleCacheMiddleware(
        IChordDefinitionRepository chordDefinitionRepository,
        IScaleDefinitionRepository scaleDefinitionRepository,
        IScaleDefinitionCache scaleDefinitionCache,
        IChordDefinitionCache chordDefinitionCache) : IMiddleware
    {
        private readonly IChordDefinitionRepository _chordDefinitionRepository = chordDefinitionRepository;
        private readonly IScaleDefinitionRepository _scaleDefinitionRepository = scaleDefinitionRepository;
        private readonly IScaleDefinitionCache _scaleDefinitionCache = scaleDefinitionCache;
        private readonly IChordDefinitionCache _chordDefinitionCache = chordDefinitionCache;

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
            if (!_chordDefinitionCache.ChordDefinitions!.Any())
            {
                var chordDefinitions = await _chordDefinitionRepository.GetAllChordDefinitions();

                await _chordDefinitionCache.Initialise(chordDefinitions);
            }
        }
    }
}
