using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.Web.Infrastructure.Models.ChordDefinition;

namespace Keyify.Infrastructure.Repository.Interfaces
{
    public interface IChordDefinitionRepository
    {
        public Task<ChordDefinitionExistsResult> CheckChordDefinitionExists(ChordDefinitionInsertRequest request);
        public Task<List<ChordDefinitionEntity>> GetAllChordDefinitions();
        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds);
        public Task<Tuple<bool, string>> InsertChordDefinition(ChordDefinitionInsertRequest request);
    }
}
