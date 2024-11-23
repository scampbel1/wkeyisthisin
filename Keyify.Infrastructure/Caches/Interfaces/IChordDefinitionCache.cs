using Keyify.Services.Models;
using Keyify.Web.Infrastructure.Models.ChordDefinition;

namespace Keyify.Infrastructure.Caches.Interfaces
{
    public interface IChordDefinitionCache
    {
        public List<ChordDefinition> ChordDefinitions { get; set; }

        public Task Initialise(List<ChordDefinitionEntity> chordDefinitions);

        public Task Sync(List<ChordDefinition> chordDefinitions);
    }
}
