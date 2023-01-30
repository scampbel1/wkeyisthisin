﻿using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyClassLibrary.Models.Interfaces;
using System.Linq;

namespace KeyifyWebClient.Models.Instruments
{
    public class CustomUkuleleTuning : ITuning
    {
        private readonly Note[] _notes;

        public CustomUkuleleTuning(Note[] notes)
        {
            _notes = notes;
        }

        public CustomUkuleleTuning(string notes)
        {
            _notes = NoteHelper.ConvertStringInputToNotes(notes);
        }

        public Note[] Notes => _notes;

        public int StringCount => _notes.Count();
    }
}
