using Keyify.Services.Models;

namespace Keyify.Service.Interfaces
{
    public interface IChordDefinitionGroupingHtmlService
    {
        public string GenerateChordDefinitionsHtml(IEnumerable<ChordDefinition> chordDefinitions);
    }
}
