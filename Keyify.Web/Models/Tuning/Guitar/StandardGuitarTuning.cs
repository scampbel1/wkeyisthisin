using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Models.Interfaces;

namespace KeyifyWebClient.Models.Instruments
{
    public class StandardGuitarTuning : ITuning
    {
        private readonly Note[] _notes = new Note[6]
        {
            Note.E,
            Note.A,
            Note.D,
            Note.G,
            Note.B,
            Note.E
        };

        public virtual Note[] ReturnNotes()
        {
            return _notes;
        }

        public int ReturnStringCount()
        {
            return _notes.Length;
        }
    }
}