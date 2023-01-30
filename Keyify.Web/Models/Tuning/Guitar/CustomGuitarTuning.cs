using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyClassLibrary.Models.Interfaces;

namespace KeyifyWebClient.Models.Instruments
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

        public Note[] Notes => _notes;

        public int StringCount => _notes.Length;
    }
}