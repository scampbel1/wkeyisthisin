using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using Keyify.Web.Services.Interfaces;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Keyify.Web.Service
{
    public class ScaleGroupingHtmlService : IScaleGroupingHtmlService
    {
        public string GenerateKeysAndScalesTable(
            IEnumerable<Note> selectedNotes,
            InstrumentType instrumentType,
            List<ScaleGroupingEntry> availableKeyGroups,
            List<ScaleGroupingEntry> availableScaleGroups,
            string selectedScale)
        {
            if (!availableKeyGroups.Any() && !availableScaleGroups.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.Append("<table class=\"scaleTable\">");

            GenerateKeys(selectedNotes, instrumentType, availableKeyGroups, selectedScale, sb);
            GenerateScales(selectedNotes, instrumentType, availableScaleGroups, selectedScale, sb);

            sb.Append("</table>");

            return sb.ToString();

            void GenerateKeys(IEnumerable<Note> selectedNotes, InstrumentType instrumentType, List<ScaleGroupingEntry> availableKeyGroups, string selectedScale, StringBuilder sb)
            {
                GenerateAvailableKeysAndScalesSection(selectedNotes, instrumentType, availableKeyGroups, sb, selectedScale);
            }

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

            while (count < scaleGroupingEntries.Count())
            {
                sb.Append("<tr>");

                if (scaleGroupingEntries.Count() - count >= 2)
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

            //Blank Row to separate Keys and Scales
            sb.Append("<tr class=\"keyAndScaleSeparator\">");
            sb.Append($"<td></td>");
            sb.Append($"<td></td>");
            sb.Append($"<td></td>");
            sb.Append($"<td></td>");
            sb.Append("</tr>");
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
                    gs.ColloquialismIncludingFormalName_Sharp,
                    gs.Popularity
                });

            foreach (var availableScale in scaleEntries)
            {
                var selectedNotesString = string.Join(",", selectedNotes.Select(s => $"'{s}'"));

                var scaleText = $"{availableScale.ColloquialismIncludingFormalName_Sharp} ({availableScale.Popularity})";

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
        }
    }
}
