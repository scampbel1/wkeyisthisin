﻿using Keyify.Infrastructure.Models.ScaleDefinition;
using Keyify.Infrastructure.Repository.Interfaces;

namespace Keyify.Infrastructure.Repository
{
    public class ScaleDefinitionRepository : IScaleDefinitionRepository
    {
        public Task<bool> DoesScaleDefinitionExist(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScaleDefinitionEntity>> GetAllScaleDefinitions()
        {
            throw new NotImplementedException();
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
