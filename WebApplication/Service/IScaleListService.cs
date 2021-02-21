using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;

namespace Keyify.Service
{
    public interface IScaleListService
    {
        IEnumerable<ScaleEntry> GetScaleList();
        IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes);
    }
}
