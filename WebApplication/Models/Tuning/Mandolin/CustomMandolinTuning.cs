using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyClassLibrary.Models.Interfaces;

namespace KeyifyWebClient.Models.Instruments
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