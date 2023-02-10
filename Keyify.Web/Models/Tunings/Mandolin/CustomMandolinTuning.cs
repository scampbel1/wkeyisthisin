using Keyify.Web.Models.Tunings;
using KeyifyClassLibrary.Enums;

namespace KeyifyWebClient.Models.Instruments
{
    public class CustomMandolinTuning : Tuning
    {
        private readonly Note[] _notes;

        public CustomMandolinTuning(Note[] notes)
        {
            _notes = notes;
        }

        public override Note[] Notes => _notes;

        public override int StringCount => _notes.Length;
    }
}