using System;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;
using KeyifyClassLibrary.Core.Domain.Tuning;

namespace Keyify.Domain.Tuning.Bass
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