using Keyify.Web.Models.Tunings;
using KeyifyClassLibrary.Enums;
using System.Linq;

namespace KeyifyWebClient.Models.Instruments
{
    public class CustomUkuleleTuning : Tuning
    {
        private readonly Note[] _notes;

        public CustomUkuleleTuning(Note[] notes)
        {
            _notes = notes;
        }

        public override Note[] Notes => _notes;

        public override int StringCount => _notes.Count();
    }
}
