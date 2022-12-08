using Keyify.Models.Service_Models;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Service.Interfaces
{
    public interface IChordService
    {
        public List<ChordDefinition> FindChordWithNoteSequence(Note[] notes);
    }
}
