using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using Keyify.Web.Infrastructure.Repository.Interfaces;

namespace Keyify.Service
{
    public class ChordDefinitionService : IChordDefinitionService
    {
        private readonly IChordDefinitionDataCache _chordDefinitionCache;
        private readonly IChordDefinitionRepository _chordDefinitionRepository;

        public ChordDefinitionService(IChordDefinitionDataCache chordDefinitionCache, IChordDefinitionRepository chordDefinitionRepository)
        {
            _chordDefinitionCache = chordDefinitionCache;
            _chordDefinitionRepository = chordDefinitionRepository;

            Task.WhenAll(InitialiseChordDefinitionCache());
        }

        public async Task<List<ChordDefinition>> FindChordDefinitions(Note[] notes)
        {
            var result = new List<ChordDefinition>();

            //TODO: Sync with Database

            if (notes != null && _chordDefinitionCache.ChordDefinitions != null)
            {
                var chordDefinitions = await Task.FromResult(_chordDefinitionCache.ChordDefinitions.Where(c => c.IsSubsetOf(notes)).ToList());

                result.AddRange(chordDefinitions);
            }

            return result;
        }

        public async Task SyncWithDatabase()
        {
            if (_chordDefinitionCache.ChordDefinitions != null)
            {
                var existingChordDefinitionIds = _chordDefinitionCache.ChordDefinitions.Select(c => c.Id).ToList();

                var newChordDefinitions = await _chordDefinitionRepository.SyncChordDefinitions(existingChordDefinitionIds);

                //TODO: Install automapper and fluent validation for null references
                //_chordDefinitionCache.ChordDefinitions = newChordDefinitions;

                //TODO: Add logging
            }
        }

        public async Task InitialiseChordDefinitionCache()
        {
            //Dictionary<string, Interval[]>

            var chordDefinitionDictionary = new Dictionary<string, Interval[]>();

            var chordDefinitionEntities = await _chordDefinitionRepository.GetAllChordDefinitions();

            //TODO: Install automapper and fluent validation for null references
            //_chordDefinitionCache.ChordDefinitions = newChordDefinitions;

            //TODO: Add logging

            foreach (var chordDefinition in chordDefinitionEntities)
            {
                //TODO: Remove ! postfix once validation is in place
                chordDefinitionDictionary.Add(chordDefinition.Name!, chordDefinition.Intervals!);
            }

            await _chordDefinitionCache.Initialise(chordDefinitionDictionary);
        }
    }
}
