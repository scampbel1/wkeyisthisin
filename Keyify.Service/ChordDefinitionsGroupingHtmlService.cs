using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using System.Text;

namespace Keyify.Service
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
                var chordDefinitionTypeGrouping = chordDefinitions.Where(c => c.Popularity == rating).GroupBy(c => c.Type);

                var popularityIcon = GetChordPopularityIcon(chordDefinitionTypeGrouping.First().First().Popularity).Item2;

                foreach (var chordDefinitionType in chordDefinitionTypeGrouping)
                {
                    sb.Append($"<span style=\"font-size:xx-small;\">{popularityIcon} </span>");

                    foreach (var chord in chordDefinitionType)
                    {
                        sb.Append($"<span class=\"scaleResult scaleText\">{chord.Label} </span>");
                    }

                    sb.AppendLine("<br/>");
                }
            }

            return sb.ToString();
        }

        public (string, string) GetChordPopularityIcon(int popularity)
        {
            switch (popularity)
            {
                case 1:
                    return ("Common", "\U0001F7E2");
                case 2:
                    return ("Less Common", "\U0001F7E1");
                case 3:
                    return ("Used Frequently", "\U0001F7E0");
                case 4:
                    return ("Used Infrequently", "\U0001F534");
                default:
                    return ("Unknown", $"{popularity}");
            }
        }
    }
}
