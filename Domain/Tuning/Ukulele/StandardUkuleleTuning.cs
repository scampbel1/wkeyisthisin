using System.Linq;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Tuning;

namespace Keyify.Domain.Tuning.Ukulele
{
    public class StandardUkuleleTuning : ITuning
    {
        private readonly Note[] _notes;

        public StandardUkuleleTuning()
        {
            _notes = new Note[] { Note.G, Note.C, Note.E, Note.A };
        }

        public Note[] ReturnNotes()
        {
            return _notes;
        }

        public int ReturnStringCount()
        {
            return _notes.Count();
        }
    }
}