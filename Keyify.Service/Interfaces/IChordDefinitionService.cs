using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Service.Interfaces
{
    public interface IChordDefinitionService
    {
        public Task<List<ChordDefinition>> FindChordDefinitions(Note[] notes);

        //public Task SyncWithDatabase();

        //public Task<Tuple<bool, string>> InsertChordDefinition(ChordDefinitionInsertRequest request);
    }
}
