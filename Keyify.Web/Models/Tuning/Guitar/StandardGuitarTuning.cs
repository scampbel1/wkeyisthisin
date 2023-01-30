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

        public virtual Note[] Notes => _notes;

        public int StringCount => _notes.Length;
    }
}