using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;
using KeyifyClassLibrary.Core.Domain.Tuning;
using System.Linq;

namespace Keyify.Domain.Tuning.Ukulele
{
    public class CustomUkuleleTuning : ITuning
    {
        private readonly Note[] _notes;

        public CustomUkuleleTuning(Note[] notes)
        {
            _notes = notes;
        }

        public CustomUkuleleTuning(string notes)
        {
            _notes = NoteHelper.ConvertStringInputToNotes(notes);
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
