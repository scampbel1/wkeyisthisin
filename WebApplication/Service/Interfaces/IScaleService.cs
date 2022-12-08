using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Service.Interfaces
{
    public interface IScaleService
    {
        public List<ScaleEntry> Scales { get; }
        IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes);
    }
}
