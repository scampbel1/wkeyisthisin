using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;
using System;

namespace KeyifyWebClient.Core.Models
{
    public class FretboardNote : IEquatable<FretboardNote>
    {
        public Note Note { get; set; }
        public string Sharp { get; set; }
        public bool Selected { get; set; }
        public bool InSelectedScale { get; set; }

        public FretboardNote(Note note)
        {
            Note = note;
            Selected = false;
            InSelectedScale = false;
            Sharp = NoteHelper.ConvertNoteToStringEquivalent(note, true);
        }

        public bool Equals(FretboardNote other)
        {
            return Note == other.Note;
        }
    }
}