using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;

namespace Keyify.Models.Service
{
    public class ScaleDefinitionService : IScaleDefinitionService
    {
        private readonly IScaleDefinitionCache _scaleDefinitionCache;
        private readonly IScaleDefinitionRepository _scaleDefinitionRepository;
        public List<ScaleDefinition> ScaleDefinitions { get => _scaleDefinitionCache.ScaleDefinitions; }

        public ScaleDefinitionService(IScaleDefinitionCache scaleDefinitionCache, IScaleDefinitionRepository scaleDefinitionRepository)
        {
            _scaleDefinitionCache = scaleDefinitionCache;
            _scaleDefinitionRepository = scaleDefinitionRepository;
        }

        public async Task InitialiseScaleDefinitionCache()
        {
            var scaleDefinitionEntities = await _scaleDefinitionRepository.GetAllScaleDefinitions();

            //TODO: Install automapper and fluent validation for null references

            //TODO: Add logging

            await _scaleDefinitionCache.Initialise(scaleDefinitionEntities);
        }

        public Task<List<ScaleDefinition>> Sync(int[] scaleDefinitionIds)
        {
            throw new NotImplementedException();
        }
    }
}