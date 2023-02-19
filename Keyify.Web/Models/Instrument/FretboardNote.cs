using Keyify.MusicTheory.Enums;
using System;

namespace Keyify.Web.Models.Instruments
{
    public class FretboardNote : IEquatable<FretboardNote>
    {
        public Note Note { get; set; }
        public string Sharp { get; set; }
        public bool Selected { get; set; }
        public bool InSelectedScale { get; set; }
        public string DegreeInScale { get; set; }

        public FretboardNote(Note note, string sharpNote)
        {
            Note = note;
            Selected = false;
            InSelectedScale = false;
            Sharp = sharpNote;
        }

        public bool Equals(FretboardNote other)
        {
            return Note == other.Note;
        }
    }
}