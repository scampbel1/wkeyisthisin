using Keyify.Services.Models;

namespace Keyify.Service.Interfaces
{
    public interface IChordDefinitionGroupingService
    {
        public (string, string) GetChordPopularityIcon(int popularity);

        public string GenerateChordDefinitionsHtml(IEnumerable<ChordDefinition> chordDefinitions);
    }
}
