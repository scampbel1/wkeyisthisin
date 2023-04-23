using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.Infrastructure.Repository;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.MusicTheory.Definitions;
using Keyify.MusicTheory.Enums;
using Keyify.Web.Infrastructure.Models.ChordDefinition;
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
            var chordDefinitions = ChordDefinitions.GetChordIntervals();

            return await Task.FromResult(chordDefinitions.Select(c => new ChordDefinitionEntity() { Name = c.Key.ToString(), Intervals = c.Value }).ToList());
        }

        public Task<Tuple<bool, string>> InsertChordDefinition(ChordDefinitionInsertRequest chordDefinitionRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds)
        {
            throw new NotImplementedException();
        }

        public Task<ChordDefinitionExistsResult> CheckChordDefinitionExists(string name, Interval[] intervals)
        {
            throw new NotImplementedException();
        }
    }
}
