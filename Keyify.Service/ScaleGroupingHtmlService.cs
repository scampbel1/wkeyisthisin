using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using Keyify.Web.Services.Interfaces;
using System.Text;

namespace Keyify.Web.Service
{
    public class ScaleGroupingHtmlService : IScaleGroupingHtmlService
    {

        //TODO: Convert parameters to Model
        public string GenerateAvailableKeysAndScalesTable(IEnumerable<Note> selectedNotes, InstrumentType instrumentType, List<ScaleGroupingEntry> availableKeyGroups, List<ScaleGroupingEntry> availableScaleGroups)
        {
            if (!availableKeyGroups.Any() && !availableScaleGroups.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.Append("<table class=\"scaleTable\">");

            GenerateAvailableKeysAndScalesSection(selectedNotes, instrumentType, availableKeyGroups, sb);
            GenerateAvailableKeysAndScalesSection(selectedNotes, instrumentType, availableScaleGroups, sb);

            sb.Append("</table>");

            return sb.ToString();
        }

        //TODO: Convert parameters to Model
        private void GenerateAvailableKeysAndScalesSection(IEnumerable<Note> selectedNotes, InstrumentType instrumentType, List<ScaleGroupingEntry> scaleGroupingEntries, StringBuilder sb)
        {
            var count = 0;

            while (count < scaleGroupingEntries.Count())
            {
                sb.Append("<tr>");

                if (scaleGroupingEntries.Count() - count >= 2)
                {
                    AddScalesToNoteSet(selectedNotes, instrumentType, scaleGroupingEntries, sb, count, false);
                    AddScalesToNoteSet(selectedNotes, instrumentType, scaleGroupingEntries, sb, count, true);

                    count += 2;
                }
                else
                {
                    AddScalesToNoteSet(selectedNotes, instrumentType, scaleGroupingEntries, sb, count, false);

                    //No more Scale Groups
                    sb.Append($"<td></td>");
                    sb.Append($"<td></td>");

                    count++;
                }

                sb.Append("</tr>");
            }

            //Blank Row to separate Keys and Scales
            sb.Append("<tr class=\"keyAndScaleSeparator\">");
            sb.Append($"<td></td>");
            sb.Append($"<td></td>");
            sb.Append($"<td></td>");
            sb.Append($"<td></td>");
            sb.Append("</tr>");
        }

        //TODO: Convert parameters to Model
        private void AddScalesToNoteSet(IEnumerable<Note> selectedNotes, InstrumentType instrumentType, List<ScaleGroupingEntry> scaleGroupingEntries, StringBuilder sb, int count, bool isNeighbouringScaleGroup)
        {
            count = isNeighbouringScaleGroup ? count += 1 : count;

            sb.Append($"<td class=\"scaleResultLabelColumn\"><span class=\"scaleResultLabel\">{scaleGroupingEntries[count].NotesGroupingLabelHtml}</span></td>");

            sb.Append($"<td class=\"scaleResultColumn\">");

            foreach (var availableScale in scaleGroupingEntries[count].GroupedScales.Select(gs => new KeyValuePair<string, string>(gs.ScaleLabel, gs.ColloquialismIncludingFormalName_Sharp)))
            {
                sb.Append($"<a class=\"scaleResult scaleText\" onclick=\"UpdateModel('/{instrumentType.ToString()}/UpdateFretboardModel', '{availableScale.Key}', null, {$"[{string.Join(',', selectedNotes.Select(s => $"'{s}'"))}]"} )\">{availableScale.Value}</a>&nbsp;");
            }

            sb.Append($"</td>");
        }
    }
}
