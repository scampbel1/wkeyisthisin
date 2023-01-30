using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Models.Interfaces;
using System.Linq;

namespace KeyifyWebClient.Models.Instruments
{
    public class StandardUkuleleTuning : ITuning
    {
        private readonly Note[] _notes;

        public StandardUkuleleTuning()
        {
            _notes = new Note[] { Note.G, Note.C, Note.E, Note.A };
        }

        public Note[] Notes => _notes;

        public int StringCount => _notes.Count();
    }
}