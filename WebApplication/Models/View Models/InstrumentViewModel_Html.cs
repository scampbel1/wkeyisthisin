using Keyify.Models.View_Models.Misc;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyifyWebClient.Models.ViewModels
{
    public partial class InstrumentViewModel
    {
        public string AvailableKeysAndScalesTableHtml => GenerateAvailableKeysAndScalesTable(AvailableKeyGroups, AvailableScaleGroups);

        private string GenerateAvailableKeysAndScalesTable(List<ScaleGroupingEntry> availableKeyGroups, List<ScaleGroupingEntry> availableScaleGroups)
        {
            if (!availableKeyGroups.Any() && !availableScaleGroups.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.Append("<table class=\"scaleTable\">");

            GenerateAvailableKeysAndScalesSection(availableKeyGroups, sb);
            GenerateAvailableKeysAndScalesSection(availableScaleGroups, sb);

            sb.Append("</table>");

            return sb.ToString();
        }

        private void GenerateAvailableKeysAndScalesSection(List<ScaleGroupingEntry> scaleGroupingEntries, StringBuilder sb)
        {
            var count = 0;

            while (count < scaleGroupingEntries.Count())
            {
                sb.Append("<tr>");

                if (scaleGroupingEntries.Count() - count >= 2)
                {
                    AddScalesToNoteSet(scaleGroupingEntries, sb, count, false);
                    AddScalesToNoteSet(scaleGroupingEntries, sb, count, true);

                    count += 2;
                }
                else
                {
                    AddScalesToNoteSet(scaleGroupingEntries, sb, count, false);

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


        private void AddScalesToNoteSet(List<ScaleGroupingEntry> scaleGroupingEntries, StringBuilder sb, int count, bool isNeighbouringScaleGroup)
        {
            count = isNeighbouringScaleGroup ? count += 1 : count;

            sb.Append($"<td class=\"scaleResultLabelColumn\"><span class=\"scaleResultLabel\">{scaleGroupingEntries[count].NotesGroupingLabelHtml}</span></td>");

            sb.Append($"<td class=\"scaleResultColumn\">");

            foreach (var availableScale in scaleGroupingEntries[count].GroupedScales.Select(gs => new KeyValuePair<string, string>(gs.ScaleLabel, gs.UserReadableLabelIncludingColloquialism_Sharp)))
            {
                sb.Append($"<a class=\"scaleResult scaleText\" onclick=\"UpdateModel('/{InstrumentName}/UpdateFretboardModel', '{availableScale.Key}', null, {$"[{string.Join(',', SelectedNotes.Select(s => $"'{s.Note}'"))}]"} )\">{availableScale.Value}</a>&nbsp;");
            }

            sb.Append($"</td>");
        }
    }
}
