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

        public Note[] Notes => _notes;

        public int StringCount => _notes.Length;
    }
}
