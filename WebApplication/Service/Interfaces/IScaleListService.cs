using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Service.Interface
{
    public interface IScaleListService
    {
        List<ScaleEntry> GetScaleList();
        IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes);
    }
}
