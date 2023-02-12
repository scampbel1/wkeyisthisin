using Keyify.Models.ServiceModels;
using System.Collections.Generic;

namespace Keyify.Web.Service.Interfaces
{
    public interface IChordTemplateGroupingHtmlService
    {
        public string GenerateChordTemplateTableHtml(IEnumerable<ChordTemplate> chordTemplates);
    }
}
