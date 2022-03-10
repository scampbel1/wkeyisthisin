using Keyify.Models.View_Models.Misc;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyifyWebClient.Models.ViewModels
{
    public partial class InstrumentViewModel
    {
        public string AvailableScalesTable => GenerateAvailableScalesTable(AvailableScaleGroups);

        public string AvailableKeysTable => GenerateAvailableScalesTable(AvailableKeyGroups);

        private string GenerateAvailableScalesTable(List<ScaleGroupingEntry> scaleGroupingEntries)
        {
            if (scaleGroupingEntries.Count() < 1)
            {
                return string.Empty;
            }

            var count = 0;

            var sb = new StringBuilder();

            sb.Append("<table class=\"scaleTable\">");

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

            sb.Append("</table>");

            return sb.ToString();
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
