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

        private void GeneratePopulatedRows(StringBuilder sb, IEnumerable<ChordDefinition> chordDefinitions)
        {
            var count = 0;
            var chordDefinitionsList = chordDefinitions.ToList();

            while (count < chordDefinitions.Count())
            {
                sb.Append("<tr>");

                if (chordDefinitions.Count() - count >= 2)
                {
                    AddScalesToNoteSet(chordDefinitionsList[count], sb, ref count, false);
                    AddScalesToNoteSet(chordDefinitionsList[count], sb, ref count, true);
                }
                else
                {
                    AddScalesToNoteSet(chordDefinitionsList[count], sb, ref count, false);

                    sb.Append($"<td></td>");
                    sb.Append($"<td></td>");
                }

                sb.Append("</tr>");
            }
        }

        private void AddScalesToNoteSet(ChordDefinition chordDefinitions, StringBuilder sb, ref int count, bool isNeighbouringScaleGroup)
        {
            count = isNeighbouringScaleGroup ? count += 1 : count;

            sb.Append($"<td class=\"scaleResultColumn\">");
            sb.Append($"<span class=\"scaleResult scaleText\">{chordDefinitions.Name}</span>");
            sb.Append($"</td>");

            count++;
        }
    }
}
