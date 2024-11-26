using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Keyify.Models.Service
{
    public class ScaleDefinitionService(
        IMemoryCache memoryCache,
        IScaleDefinitionRepository scaleDefinitionRepository) : IScaleDefinitionService
    {
        private const string CacheKey = "ScaleDefinitions";
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly IScaleDefinitionRepository _scaleDefinitionRepository = scaleDefinitionRepository;

        public List<ScaleDefinition> ScaleDefinitions
        {
            get
            {
                _memoryCache.TryGetValue(CacheKey, out List<ScaleDefinition> scaleDefinitions);

                return scaleDefinitions ?? Enumerable.Empty<ScaleDefinition>().ToList();
            }
        }
    }
}