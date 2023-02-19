using Keyify.Web.Infrastructure.Models.ChordDefinition;

namespace Keyify.Web.Infrastructure.Repository.Interfaces
{
    public interface IChordDefinitionRepository
    {
        public Task<ChordDefinitionEntity> GetChordDefinition(ChordDefinitionRequest chordDefinitionRequest);
        public Task<List<ChordDefinitionEntity>> GetAllChordDefinitions();
        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds);
        public Task InsertChordDefinition(ChordDefinitionRequest chordDefinitionRequest);
    }
}
