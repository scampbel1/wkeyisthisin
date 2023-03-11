using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Models;
using System.Text;

namespace Keyify.Web.Service
{
    public class ChordDefinitionsGroupingHtmlService : IChordDefinitionGroupingHtmlService
    {
        private readonly INoteFormatService _noteFormatService;
        private readonly Dictionary<Note, string> _sharpNoteDictionary;

        public ChordDefinitionsGroupingHtmlService(INoteFormatService noteFormatService)
        {
            _noteFormatService = noteFormatService;
            _sharpNoteDictionary = _noteFormatService.SharpNoteDictionary;
        }

        public string GenerateChordDefinitionsTableHtml(IEnumerable<ChordDefinition> chordDefinitions)
        {
            if (chordDefinitions == null && chordDefinitions.Any())
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

        public string GenerateNotesGroupingLabelHtml(IEnumerable<Note> selectedNotes, List<ScaleEntry> groupedScales)
        {
            if (groupedScales == null || !groupedScales.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            var firstScaleInGroup = groupedScales.FirstOrDefault();

            if (firstScaleInGroup != null)
            {
                var noteSet = firstScaleInGroup.Scale.NotesHashSet;

                sb.Append("<span class=\"scaleResultLabel\">");

                foreach (var note in noteSet)
                {
                    if (selectedNotes.Contains(note))
                    {
                        sb.Append($"<span class=\"scaleSetLabelNote matchedScaleSetLabelNote\">{_sharpNoteDictionary[note]}</span>");
                    }
                    else
                    {
                        sb.Append($"<span class=\"scaleSetLabelNote\">{_sharpNoteDictionary[note]}</span>");
                    }
                }

                sb.Append("</span>");
            }

            return sb.ToString();
        }
    }
}
