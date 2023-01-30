﻿using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Models.Interfaces;

namespace KeyifyWebClient.Models.Instruments
{
    public class StandardMandolinTuning : ITuning
    {
        private readonly Note[] _notes;

        public StandardMandolinTuning()
        {
            _notes = new Note[] { Note.G, Note.D, Note.A, Note.E };
        }

        public Note[] Notes => _notes;

        public int StringCount => _notes.Length;
    }
}