using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using System;

namespace KeyifyWebClient.Models.Instruments
{
    public class FretboardNote : IEquatable<FretboardNote>
    {
        public Note Note { get; set; }
        public string Sharp { get; set; }
        public bool Selected { get; set; }
        public bool InSelectedScale { get; set; }
        public string DegreeInScale { get; set; }

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