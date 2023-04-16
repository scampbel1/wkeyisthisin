using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Service.Interfaces
{
    public interface IChordDefinitionService
    {
        public Task<List<ChordDefinition>> FindChordDefinitions(Note[] notes);

        public Task SyncWithDatabase();

        public Task<bool> DoesChordDefinitionExist(string chordDefinitionName, Interval[] intervals);

        public Task<bool> InsertChordDefinition(string chordDefinitionName, Interval[] intervals);
    }
}
