using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using Keyify.Web.Services.Interfaces;
using System.Text;

namespace Keyify.Web.Service
{
    public class ScaleGroupingHtmlService : IScaleGroupingHtmlService
    {
        public string GenerateScalesTable(
            IEnumerable<Note> selectedNotes,
            InstrumentType instrumentType,
            List<ScaleGroupingEntry> availableScaleGroups,
            string selectedScale)
        {
            if (!availableScaleGroups.Any())
            {
                return string.Empty;
            }

            var limitedGroupScale = availableScaleGroups.Take(8).ToList();

            var sb = new StringBuilder();

            sb.Append("<table class=\"scaleTable\">");

            GenerateScales(selectedNotes, instrumentType, limitedGroupScale, selectedScale, sb);

            sb.Append("</table>");

            return sb.ToString();

            void GenerateScales(IEnumerable<Note> selectedNotes, InstrumentType instrumentType, List<ScaleGroupingEntry> limitedGroupScale, string selectedScale, StringBuilder sb)
            {
                GenerateAvailableKeysAndScalesSection(selectedNotes, instrumentType, limitedGroupScale, sb, selectedScale);
            }
        }

        private void GenerateAvailableKeysAndScalesSection(
            IEnumerable<Note> selectedNotes,
            InstrumentType instrumentType,
            List<ScaleGroupingEntry> scaleGroupingEntries,
            StringBuilder sb,
            string selectedScale)
        {
            var count = 0;

            while (count < scaleGroupingEntries.Count)
            {
                sb.Append("<tr>");

                if (scaleGroupingEntries.Count - count >= 2)
                {
                    AddScalesToNoteSet(selectedNotes, instrumentType, scaleGroupingEntries, sb, count, isNeighbouringScaleGroup: false, selectedScale);
                    AddScalesToNoteSet(selectedNotes, instrumentType, scaleGroupingEntries, sb, count, isNeighbouringScaleGroup: true, selectedScale);

                    count += 2;
                }
                else
                {
                    AddScalesToNoteSet(selectedNotes, instrumentType, scaleGroupingEntries, sb, count, false, selectedScale);

                    //No more Scale Groups
                    sb.Append($"<td></td>");
                    sb.Append($"<td></td>");

                    count++;
                }

                sb.Append("</tr>");
            }
        }

        private void AddScalesToNoteSet(
            IEnumerable<Note> selectedNotes,
            InstrumentType instrumentType,
            List<ScaleGroupingEntry> scaleGroupingEntries,
            StringBuilder sb,
            int count,
            bool isNeighbouringScaleGroup,
            string selectedScale)
        {
            count = isNeighbouringScaleGroup ? count += 1 : count;

            sb.Append($"<td class=\"scaleResultCell\"><span class=\"scaleResultLabel\">{scaleGroupingEntries[count].NotesGroupingLabelHtml}</span></td>");

            sb.Append($"<td class=\"scaleResultCell\">");

            var scaleEntries = scaleGroupingEntries[count]
                .GroupedScales
                .Select(gs => new
                {
                    gs.ScaleLabel,
                    gs.FullName_Sharp,
                    gs.Popularity
                });

            var selectedNotesString = string.Join(",", selectedNotes.Select(s => $"'{s}'"));

            foreach (var availableScale in scaleEntries.GroupBy(s => s.Popularity))
            {
                sb.Append($"<span style=\"font-size:xx-small;\">{GetScalePopularityIcon(availableScale.First().Popularity).Item2}</span>");

                foreach (var scale in availableScale)
                {
                    var scaleText = $"<span>{scale.FullName_Sharp}</span>";

                    if (!scale.ScaleLabel.Equals(selectedScale))
                    {
                        var onclick = $"UpdateModel('/{instrumentType.ToString()}/UpdateFretboardModel'," +
                            $" '{scale.ScaleLabel}', null, [{selectedNotesString}])";

                        sb.Append($"<a class=\"scaleResult scaleText\" onclick=\"{onclick}\">{scaleText}</a>&nbsp;");
                    }
                    else
                    {
                        var onclick = $"UpdateModel('/{instrumentType.ToString()}/UpdateFretboardModel', null, null, [{selectedNotesString}])";
                        var style = "text-decoration: underline double; font-weight: bold;";

                        sb.Append($"<a class=\"scaleResult scaleText\" style=\"{style}\" onclick=\"{onclick}\">{scaleText}</a>&nbsp;");
                    }
                }

                sb.Append("<br/>");
            }

            sb.Append($"</td>");

        }

        public (string, string) GetScalePopularityIcon(int popularity)
        {
            switch (popularity)
            {
                case 0:
                    return ("Key", "🔑");
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
