using KeyifyClassLibrary.Core.Domain.Enums;

namespace KeyifyClassLibrary.Core.Domain.Tuning.Guitar
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