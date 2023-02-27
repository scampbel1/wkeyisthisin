using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;

namespace Keyify.Models.Service
{
    public class ScaleDefinitionService : IScaleDefinitionService
    {
        private readonly IScaleDefinitionCache _scaleDefinitionCache;

        public List<ScaleDefinition> ScaleDefinitions { get; set; }

        public ScaleDefinitionService(IScaleDefinitionCache scaleDefinitionCache)
        {
            _scaleDefinitionCache = scaleDefinitionCache;

            Task.WhenAll(InitialiseChordDefinitionCache());
        }

        public async Task InitialiseChordDefinitionCache()
        {
            await _scaleDefinitionCache.Initialise();

            ScaleDefinitions = _scaleDefinitionCache.ScaleDefinitions;
        }
    }
}