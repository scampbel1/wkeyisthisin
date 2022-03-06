using Keyify.Models.Service_Models;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Service.Interfaces
{
    public interface IChordListService
    {
        List<ChordEntry> GetChordList();
        IEnumerable<ChordEntry> FindChords(IEnumerable<Note> selectedNotes);
    }
}
