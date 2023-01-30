using Keyify.Web.Models.Tunings;
using KeyifyClassLibrary.Enums;

namespace KeyifyWebClient.Models.Instruments
{
    public class StandardMandolinTuning : Tuning
    {
        private readonly Note[] _notes;

        public StandardMandolinTuning()
        {
            _notes = new Note[] { Note.G, Note.D, Note.A, Note.E };
        }

        public override Note[] Notes => _notes;

        public override int StringCount => _notes.Length;
    }
}