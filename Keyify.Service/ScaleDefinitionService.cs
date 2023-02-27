using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;

namespace Keyify.Models.Service
{
    public class ScaleDefinitionService : IScaleDefinitionService
    {
        private readonly IScaleDefinitionCache _scaleDefinitionCache;
        private readonly IScaleDefinitionRepository _scaleDefinitionRepository;

        public ScaleDefinitionService(IScaleDefinitionCache scaleDefinitionCache, IScaleDefinitionRepository scaleDefinitionRepository)
        {
            _scaleDefinitionCache = scaleDefinitionCache;
            _scaleDefinitionRepository = scaleDefinitionRepository;

            Task.WhenAll(InitialiseChordDefinitionCache());
        }

        public List<ScaleDefinition> ScaleDefinitions { get => _scaleDefinitionCache.ScaleDefinitions; }

        public async Task InitialiseChordDefinitionCache()
        {
            var scaleDefinitionEntities = await _scaleDefinitionRepository.GetAllScaleDefinitions();

            //TODO: Install automapper and fluent validation for null references
            //_chordDefinitionCache.ChordDefinitions = newChordDefinitions;

            //TODO: Add logging

            //foreach (var chordDefinition in scaleDefinitionEntities)
            //{
            //    //TODO: Remove ! postfix once validation is in place
            //    chordDefinitionDictionary.Add(chordDefinition.Name!, chordDefinition.Intervals!);
            //}

            await _scaleDefinitionCache.Initialise(scaleDefinitionEntities);
        }
    }
}