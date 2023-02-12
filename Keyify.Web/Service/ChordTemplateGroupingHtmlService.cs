﻿using Keyify.Models.ServiceModels;
using Keyify.Web.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keyify.Web.Service
{
    public class ChordTemplateGroupingHtmlService : IChordTemplateGroupingHtmlService
    {
        public string GenerateChordTemplateTableHtml(IEnumerable<ChordTemplate> chordTemplates)
        {
            if (chordTemplates == null && chordTemplates.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.Append("<table class=\"scaleTable\">");

            GeneratePopulatedRows(sb, chordTemplates);

            sb.Append("</table>");

            return sb.ToString();
        }

        private void GeneratePopulatedRows(StringBuilder sb, IEnumerable<ChordTemplate> chordTemplates)
        {
            var count = 0;
            var chordTemplateList = chordTemplates.ToList();

            while (count < chordTemplates.Count())
            {
                sb.Append("<tr>");

                if (chordTemplates.Count() - count >= 2)
                {
                    AddScalesToNoteSet(chordTemplateList[count], sb, count, false);
                    AddScalesToNoteSet(chordTemplateList[count], sb, count, true);

                    count += 2;
                }
                else
                {
                    AddScalesToNoteSet(chordTemplateList[count], sb, count, false);

                    sb.Append($"<td></td>");
                    sb.Append($"<td></td>");

                    count++;
                }

                sb.Append("</tr>");
            }
        }

        private void AddScalesToNoteSet(ChordTemplate chordTemplate, StringBuilder sb, int count, bool isNeighbouringScaleGroup)
        {
            count = isNeighbouringScaleGroup ? count += 1 : count;

            sb.Append($"<td class=\"scaleResultColumn\">");
            sb.Append($"{chordTemplate.Name}");
            sb.Append($"</td>");
        }
    }
}
