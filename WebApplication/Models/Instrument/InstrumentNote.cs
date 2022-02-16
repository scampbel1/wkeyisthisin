using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using System;

namespace KeyifyWebClient.Models.Instruments
{
    public class InstrumentNote : IEquatable<InstrumentNote>
    {
        public Note Note { get; set; }
        public string Sharp { get; set; }
        public bool Selected { get; set; }
        public bool InSelectedScale { get; set; }
        public int PositionInScale { get; set; }

        public InstrumentNote(Note note)
        {
            Note = note;
            Selected = false;
            InSelectedScale = false;
            Sharp = NoteHelper.ConvertNoteToStringEquivalent(note, true);
        }

        public bool Equals(InstrumentNote other)
        {
            return Note == other.Note;
        }
    }
}