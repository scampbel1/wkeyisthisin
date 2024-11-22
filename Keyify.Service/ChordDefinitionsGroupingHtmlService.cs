using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using System.Text;

namespace Keyify.Web.Service
{
    public class ChordDefinitionsGroupingHtmlService : IChordDefinitionGroupingHtmlService
    {
        public string GenerateChordDefinitionsHtml(IEnumerable<ChordDefinition> chordDefinitions)
        {
            if (!chordDefinitions.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            foreach (var chordDefinition in chordDefinitions)
            {
                sb.Append($"<span class=\"scaleResult scaleText\">{chordDefinition.Label} </span>");
            }

            return sb.ToString();
        }
    }
}
