using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Infrastructure.Caches.Interfaces
{
    public interface IChordDefinitionCache
    {
        public List<ChordDefinition>? ChordDefinitions { get; set; }

        public Task Initialise(Dictionary<string, Interval[]> chordDefinitions);

        public Task Sync(List<ChordDefinition> chordDefinitions);
    }
}
