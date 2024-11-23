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

            var popularityRatings = chordDefinitions.Select(c => c.Popularity).Distinct();

            foreach (var rating in popularityRatings.OrderBy(r => r))
            {
                var chordDef = chordDefinitions.Where(c => c.Popularity == rating);

                sb.Append($"<span style=\"font-size:xx-small;\">{GetChordPopularityIcon(chordDef.First().Popularity).Item2}</span>");

                foreach (var chord in chordDef)
                {
                    sb.Append($"<span class=\"scaleResult scaleText\">{chord.Label} </span>");
                }

                sb.AppendLine("<br/>");
            }

            return sb.ToString();
        }

        public (string, string) GetChordPopularityIcon(int popularity)
        {
            switch (popularity)
            {
                case 1:
                    return ("Widely Used", "\U0001F7E2");
                case 2:
                    return ("Frequently Used", "\U0001F7E1");
                case 3:
                    return ("Rarely Used", "\U0001F7E0");
                case 4:
                    return ("Very Rarely Used", "\U0001F534");
                default:
                    return ("Unknown", $"{popularity}");
            }
        }
    }
}
