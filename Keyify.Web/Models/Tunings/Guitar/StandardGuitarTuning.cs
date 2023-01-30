using Keyify.Web.Models.Tunings;
using KeyifyClassLibrary.Enums;

namespace KeyifyWebClient.Models.Instruments
{
    public class StandardGuitarTuning : Tuning
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

        public override Note[] Notes => _notes;

        public override int StringCount => _notes.Length;
    }
}