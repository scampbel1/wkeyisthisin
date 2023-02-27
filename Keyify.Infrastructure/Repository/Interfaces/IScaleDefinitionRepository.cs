using Keyify.Infrastructure.Models.ScaleDefinition;

namespace Keyify.Infrastructure.Repository.Interfaces
{
    public interface IScaleDefinitionRepository
    {
        public Task<bool> DoesScaleDefinitionExist(string name);
        public Task<List<ScaleDefinitionEntity>> GetAllScaleDefinitions();
        public Task<List<ScaleDefinitionEntity>> SyncScaleDefinitions(IEnumerable<int> existingScaleDefinitionIds);
        public Task InsertScaleDefinition(ScaleDefinitionRequest chordDefinitionRequest);
    }
}
