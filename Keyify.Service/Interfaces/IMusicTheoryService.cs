using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Web.Services.Interfaces
{
    public interface IMusicTheoryService
    {
        Task<IEnumerable<ScaleEntry>> FindScales(IEnumerable<Note> selectedNotes);
        Task<IEnumerable<ChordDefinition>> GetChordsDefinitions(Note[] selectedScaleNotes, Note[] selectedNotes);
    }
}
