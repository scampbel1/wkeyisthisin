using Keyify.Infrastructure.Models.ScaleDefinition;
using Keyify.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keyify.Web.Unit.Test.ChordTemplates.UnitTests.Mocks
{
    internal class MockScaleDefinitionRepository : IScaleDefinitionRepository
    {
        public Task<bool> DoesScaleDefinitionExist(string name)
        {
            return Task.FromResult(true);
        }

        public Task<List<ScaleDefinitionEntity>> GetAllScaleDefinitions()
        {
            return Task.FromResult(new List<ScaleDefinitionEntity>());
        }

        public Task InsertScaleDefinition(ScaleDefinitionRequest chordDefinitionRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScaleDefinitionEntity>> SyncScaleDefinitions(IEnumerable<int> existingScaleDefinitionIds)
        {
            throw new NotImplementedException();
        }
    }
}
