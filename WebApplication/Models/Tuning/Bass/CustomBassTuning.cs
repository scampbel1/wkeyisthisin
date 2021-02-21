using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyClassLibrary.Models.Interfaces;
using System;

namespace Keyify.Models.Tuning.Bass
{
    public class CustomBassTuning : ITuning
    {
        private readonly Note[] _notes;

        public CustomBassTuning(Note[] notes)
        {
            _notes = notes;
        }

        public CustomBassTuning(string notes)
        {
            _notes = NoteHelper.ConvertStringInputToNotes(notes);
        }

        public Note[] ReturnNotes()
        {
            throw new NotImplementedException();
        }

        public int ReturnStringCount()
        {
            throw new NotImplementedException();
        }
    }
}