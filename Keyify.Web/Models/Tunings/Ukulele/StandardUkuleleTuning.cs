using Keyify.MusicTheory.Enums;
using Keyify.Web.Models.Tunings;
using System.Linq;

namespace KeyifyWebClient.Models.Instruments
{
    public class StandardUkuleleTuning : Tuning
    {
        private readonly Note[] _notes;

        public StandardUkuleleTuning()
        {
            _notes = new Note[] { Note.G, Note.C, Note.E, Note.A };
        }

        public override Note[] Notes => _notes;

        public override int StringCount => _notes.Count();
    }
}