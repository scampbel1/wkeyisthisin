using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Models.Interfaces;

namespace Keyify.Domain.Tuning.Bass
{
    public class StandardBassTuning : ITuning
    {
        private readonly Note[] _notes = new Note[4]
        {
            Note.E,
            Note.A,
            Note.D,
            Note.G
        };

        public Note[] ReturnNotes()
        {
            return _notes;
        }

        public int ReturnStringCount()
        {
            return _notes.Length;
        }
    }
}
