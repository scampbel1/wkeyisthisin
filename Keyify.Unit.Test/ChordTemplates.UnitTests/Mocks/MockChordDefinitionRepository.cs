using Keyify.MusicTheory.Definitions;
using Keyify.Web.Infrastructure.Models.ChordDefinition;
using Keyify.Web.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keyify.Web.Unit.Test.ChordTemplates.UnitTests.Mocks
{
    public class MockChordDefinitionRepository : IChordDefinitionRepository
    {
        public async Task<List<ChordDefinitionEntity>> GetAllChordDefinitions()
        {
            var chordDefinitions = ChordDefinitions.GenerateChordDefinitions();

            return await Task.FromResult(chordDefinitions.Select(c => new ChordDefinitionEntity() { Name = c.Key.ToString(), Intervals = c.Value }).ToList());
        }

        public Task InsertChordDefinition(ChordDefinitionRequest chordDefinitionRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesChordDefinitionExist(string name)
        {
            throw new NotImplementedException();
        }
    }
}
