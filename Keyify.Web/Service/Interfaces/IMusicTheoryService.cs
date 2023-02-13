using Keyify.Models.Service;
using Keyify.Models.ServiceModels;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Web.Service.Interfaces
{
    public interface IMusicTheoryService
    {
        IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes);
        IEnumerable<ChordDefinition> GetChordsDefinitions(Note[] selectedScaleNotes, Note[] selectedNotes);
    }
}
