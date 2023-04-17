using Keyify.MusicTheory.Enums;
using Keyify.Web.Infrastructure.Models.ChordDefinition;

namespace Keyify.Infrastructure.Repository.Interfaces
{
    public interface IChordDefinitionRepository
    {
        public Task<Tuple<bool, string>> DoesChordDefinitionExist(string name, byte[] intervals);
        public Task<List<ChordDefinitionEntity>> GetAllChordDefinitions();
        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds);
        public Task<Tuple<bool, string>> InsertChordDefinition(ChordDefinitionRequest chordDefinitionRequest);
    }
}
