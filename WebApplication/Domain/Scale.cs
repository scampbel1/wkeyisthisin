using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;

namespace KeyifyClassLibrary.Core.Domain
{
    public class Scale
    {
        public readonly Note RootNote;
        public List<Note> Notes { get; set; }
        public HashSet<Note> NotesSet { get; set; }
        public Mode Mode { get; set; }

        public Scale(Note key, Mode mode)
        {
            RootNote = key;
            Notes = new List<Note>();
            NotesSet = new HashSet<Note>();
            Mode = mode;
        }

        public void AddNote(Note note)
        {
            Notes.Add(note);
            NotesSet.Add(note);
        }
    }
}