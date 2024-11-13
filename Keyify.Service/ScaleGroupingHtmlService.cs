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

            var sb = new StringBuilder();

            sb.Append("<table class=\"scaleTable\">");

            GenerateScales(selectedNotes, instrumentType, availableScaleGroups, selectedScale, sb);

            sb.Append("</table>");

            return sb.ToString();

            void GenerateScales(IEnumerable<Note> selectedNotes, InstrumentType instrumentType, List<ScaleGroupingEntry> availableScaleGroups, string selectedScale, StringBuilder sb)
            {
                GenerateAvailableKeysAndScalesSection(selectedNotes, instrumentType, availableScaleGroups, sb, selectedScale);
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

            sb.Append($"<td class=\"scaleResultLabelColumn\"><span class=\"scaleResultLabel\">{scaleGroupingEntries[count].NotesGroupingLabelHtml}</span></td>");

            sb.Append($"<td class=\"scaleResultColumn\">");

            var scaleEntries = scaleGroupingEntries[count]
                .GroupedScales
                .Select(gs => new
                {
                    gs.ScaleLabel,
                    gs.FullName_Sharp,
                    gs.Popularity
                });

            foreach (var availableScale in scaleEntries)
            {
                var selectedNotesString = string.Join(",", selectedNotes.Select(s => $"'{s}'"));
                
                //TODO: Try and fix the symbol size here
                var popularitySymbol = $"<span style=\"transform: scale(2);\">{GetScalePopularityIcon(availableScale.Popularity)}</span>";

                var scaleText = $"{popularitySymbol} <span>{availableScale.FullName_Sharp}</span>";

                if (!availableScale.ScaleLabel.Equals(selectedScale))
                {
                    var onclick = $"UpdateModel('/{instrumentType.ToString()}/UpdateFretboardModel'," +
                        $" '{availableScale.ScaleLabel}', null, [{selectedNotesString}])";

                    sb.Append($"<a class=\"scaleResult scaleText\" onclick=\"{onclick}\">{scaleText}</a>&nbsp;");
                }
                else
                {
                    var onclick = $"UpdateModel('/{instrumentType.ToString()}/UpdateFretboardModel', null, null, [{selectedNotesString}])";
                    var style = "text-decoration: underline double; font-weight: bold;";

                    sb.Append($"<a class=\"scaleResult scaleText\" style=\"{style}\" onclick=\"{onclick}\">{scaleText}</a>&nbsp;");
                }
            }

            sb.Append($"</td>");

            static string GetScalePopularityIcon(int popularity)
            {
                switch (popularity)
                {
                    case 0:
                        return "🔑";
                    case 1:
                        return "\U0001F7E2";
                    case 2:
                        return "\U0001F7E1";
                    case 3:
                        return "\U0001F7E0";
                    case 4:
                        return "\U0001F534";
                    default:
                        return $"({popularity})";
                }
            }
        }
    }
}
