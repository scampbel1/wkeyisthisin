using Keyify.Models.Service;
using Keyify.Models.Service_Models;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Web.Service.Interfaces
{
    public interface IMusicTheoryService
    {
        IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes);
        IEnumerable<ChordTemplate> GetChordsTemplates(string selectedScale, Note[] selectedNotes);
    }
}
