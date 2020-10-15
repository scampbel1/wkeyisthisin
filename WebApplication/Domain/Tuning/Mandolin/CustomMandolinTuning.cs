using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;
using KeyifyClassLibrary.Core.Domain.Tuning;

namespace Keyify.Domain.Tuning.Mandolin
{
    public class CustomMandolinTuning : ITuning
    {
        private readonly Note[] _notes;

        public CustomMandolinTuning(Note[] notes)
        {
            _notes = notes;
        }

        public CustomMandolinTuning(string notes)
        {
            _notes = NoteHelper.ConvertStringInputToNotes(notes);
        }

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
