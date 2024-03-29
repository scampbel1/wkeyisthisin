﻿using Keyify.MusicTheory.Enums;
using Keyify.Web.Models.Tunings;

namespace KeyifyWebClient.Models.Instruments
{
    public class CustomGuitarTuning : Tuning
    {
        private readonly Note[] _notes;

        public CustomGuitarTuning(Note[] inputNotes)
        {
            _notes = inputNotes;
        }

        public override Note[] Notes => _notes;

        public override int StringCount => _notes.Length;
    }
}