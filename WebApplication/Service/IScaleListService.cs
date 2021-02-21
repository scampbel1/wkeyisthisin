using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;

namespace Keyify.Models
{
    public interface IScaleListService
    {
        IEnumerable<ScaleListEntry> GetScaleList();
        IEnumerable<ScaleListEntry> FindScales(IEnumerable<Note> selectedNotes);
    }
}
