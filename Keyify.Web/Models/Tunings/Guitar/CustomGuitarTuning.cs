using Keyify.Web.Models.Tunings;
using KeyifyClassLibrary.Enums;

namespace KeyifyWebClient.Models.Instruments
{
    public class CustomGuitarTuning : Tuning
    {
        private readonly Note[] _notes;

        public CustomGuitarTuning(Note[] inputNotes)
        {
            _notes = inputNotes;
        }

        public CustomGuitarTuning(string inputNotes)
        {
            _notes = ConvertStringInputToNotes(inputNotes);
        }

        public override Note[] Notes => _notes;

        public override int StringCount => _notes.Length;
    }
}