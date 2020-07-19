using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Tuning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keyify.Domain.Tuning.Mandolin
{
    public class StandardMandolinTuning : ITuning
    {
        private readonly Note[] _notes;

        public StandardMandolinTuning()
        {
            _notes = new Note[] { Note.G, Note.D, Note.A, Note.E };
        }

        public Note[] ReturnNotes()
        {
            return _notes;
        }

        public int ReturnStringCount()
        {
            return _notes.Length;
        }
    }
}
