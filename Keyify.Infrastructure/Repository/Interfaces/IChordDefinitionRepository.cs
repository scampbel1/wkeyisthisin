using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.MusicTheory.Enums;
using Keyify.Web.Infrastructure.Models.ChordDefinition;

namespace Keyify.Infrastructure.Repository.Interfaces
{
    public interface IChordDefinitionRepository
    {
        public Task<ChordDefinitionFoundResult> DoesChordDefinitionExist(string name, Interval[] intervals);
        public Task<List<ChordDefinitionEntity>> GetAllChordDefinitions();
        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds);
        public Task<Tuple<bool, string>> InsertChordDefinition(ChordDefinitionInsertRequest chordDefinitionRequest);
    }
}
