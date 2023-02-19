using Keyify.Web.Infrastructure.Models.ChordDefinition;
using Keyify.Web.Infrastructure.Repository.Interfaces;

namespace Keyify.Infrastructure.Repository
{
    public class ChordDefinitionRepository : IChordDefinitionRepository
    {
        public Task<List<ChordDefinitionEntity>> GetAllChordDefinitions()
        {
            throw new NotImplementedException();
        }

        public Task<ChordDefinitionEntity> GetChordDefinition(ChordDefinitionRequest chordDefinitionRequest)
        {
            throw new NotImplementedException();
        }

        public Task InsertChordDefinition(ChordDefinitionRequest chordDefinitionRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds)
        {
            throw new NotImplementedException();
        }
    }
}
