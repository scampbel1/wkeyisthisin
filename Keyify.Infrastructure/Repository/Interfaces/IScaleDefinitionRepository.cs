using Keyify.Infrastructure.Models.ScaleDefinition;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Infrastructure.Repository.Interfaces
{
    public interface IScaleDefinitionRepository
    {
        public Task<bool> DoesScaleDefinitionExist(string name);
        public Task<bool> DoesScaleDefinitionExist(Interval[] intervals);
        public Task<List<ScaleDefinitionEntity>> GetAllScaleDefinitions();
        public Task<List<ScaleDefinitionEntity>> SyncScaleDefinitions(IEnumerable<int> existingScaleDefinitionIds);
        public Task InsertScaleDefinition(ScaleDefinition scaleDefintionInsertRequest);
    }
}
