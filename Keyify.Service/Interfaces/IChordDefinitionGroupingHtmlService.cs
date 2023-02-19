using Keyify.Services.Models;

namespace Keyify.Service.Interfaces
{
    public interface IChordDefinitionGroupingHtmlService
    {
        public string GenerateChordDefinitionsTableHtml(IEnumerable<ChordDefinition> chordDefinitions);
    }
}
