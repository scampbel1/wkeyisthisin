using Keyify.Models.ServiceModels;
using System.Collections.Generic;

namespace Keyify.Web.Service.Interfaces
{
    public interface IChordDefinitionGroupingHtmlService
    {
        public string GenerateChordDefinitionsTableHtml(IEnumerable<ChordDefinition> chordDefinitions);
    }
}
