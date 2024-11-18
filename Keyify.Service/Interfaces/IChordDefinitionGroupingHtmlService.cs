using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Service.Interfaces
{
    public interface IChordDefinitionGroupingHtmlService
    {
        public string GenerateChordDefinitionsHtml(IEnumerable<ChordDefinition> chordDefinitions);
        
        public string GenerateNotesGroupingLabelHtml(IEnumerable<Note> selectedNotes, List<ScaleEntry> groupedScales);
    }
}
