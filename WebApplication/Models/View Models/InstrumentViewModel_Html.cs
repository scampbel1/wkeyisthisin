using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyifyWebClient.Models.ViewModels
{
    public partial class InstrumentViewModel
    {
        public string AvailableScalesTable => GenerateAvailableScalesTable();

        private string GenerateAvailableScalesTable()
        {
            var count = 0;
            var availableScalesTotal = this.AvailableScaleGroups.Count;

            if (availableScalesTotal < 1)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.Append("<table>");

            while (count < availableScalesTotal)
            {
                sb.Append("<tr>");

                if (availableScalesTotal - count >= 2)
                {
                    //TODO: Remove Boilerplate Code - all of this can be moved to a method
                    sb.Append($"<td><span class=\"scaleResult\">{AvailableScaleGroups[count].NotesGroupingLabel}</span></td>");

                    sb.Append($"<td>");

                    foreach (var availableScale in AvailableScaleGroups[count].GroupedScales.Select(gs => new KeyValuePair<string, string>(gs.ScaleLabel, gs.UserReadableLabelIncludingColloquialism_Sharp)))
                    {
                        sb.Append($"<a class=\"scaleResult\" onclick=\"UpdateModel('/{InstrumentName}/UpdateFretboardModel', '{availableScale.Key}', null, {$"[{string.Join(',', SelectedNotes.Select(s => $"'{s.Note}'"))}]"} )\">{availableScale.Value}</a>&nbsp;");
                    }

                    sb.Append($"</td>");

                    sb.Append($"<td><span class=\"scaleResult\">{AvailableScaleGroups[count + 1].NotesGroupingLabel}</span></td>");

                    sb.Append($"<td>");

                    foreach (var availableScale in AvailableScaleGroups[count + 1].GroupedScales.Select(gs => new KeyValuePair<string, string>(gs.ScaleLabel, gs.UserReadableLabelIncludingColloquialism_Sharp)))
                    {
                        sb.Append($"<a class=\"scaleResult\" onclick=\"UpdateModel('/{InstrumentName}/UpdateFretboardModel', '{availableScale.Key}', null, {$"[{string.Join(',', SelectedNotes.Select(s => $"'{s.Note}'"))}]"} )\">{availableScale.Value}</a>&nbsp;");
                    }

                    sb.Append($"</td>");

                    count += 2;
                }
                else
                {
                    sb.Append($"<td><span class=\"scaleResult\">{AvailableScaleGroups[count].NotesGroupingLabel}</span></td>");

                    sb.Append($"<td>");

                    foreach (var availableScale in AvailableScaleGroups[count].GroupedScales.Select(gs => new KeyValuePair<string, string>(gs.ScaleLabel, gs.UserReadableLabelIncludingColloquialism_Sharp)))
                    {
                        sb.Append($"<a class=\"scaleResult\" onclick=\"UpdateModel('/{InstrumentName}/UpdateFretboardModel', '{availableScale.Key}', null, {$"[{string.Join(',', SelectedNotes.Select(s => $"'{s.Note}'"))}]"} )\">{availableScale.Value}</a>&nbsp;");
                    }

                    sb.Append($"</td>");

                    sb.Append($"<td></td>");
                    sb.Append($"<td></td>");

                    count++;
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");

            return sb.ToString();
        }
    }
}
