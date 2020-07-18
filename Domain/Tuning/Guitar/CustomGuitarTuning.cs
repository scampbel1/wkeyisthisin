using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;

namespace KeyifyClassLibrary.Core.Domain.Tuning.Guitar
{
    public class CustomGuitarTuning : ITuning
    {
        private readonly Note[] _notes;

        public CustomGuitarTuning(Note[] inputNotes)
        {
            _notes = inputNotes;
        }

        public CustomGuitarTuning(string inputNotes)
        {
            _notes = NoteHelper.ConvertStringInputToNotes(inputNotes);
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