using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Service.Interface
{
    public interface IScaleListService
    {
        IEnumerable<ScaleEntry> GetScaleList();
        IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes);
        Dictionary<HashSet<Note>, List<ScaleEntry>> FindScalesSortByNoteSet(IEnumerable<Note> selectedNotes);
    }
}
