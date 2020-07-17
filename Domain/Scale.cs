using System.Collections.Generic;
using KeyifyClassLibrary.Core.Domain.Enums;

namespace KeyifyClassLibrary.Core.Domain
{
    public class Scale
    {
        private readonly Note _key;
        public List<Note> Notes { get; set; }
        public HashSet<Note> NotesSet { get; set; }

        public Note GetKey()
        {
            return _key;
        }

        public Scale(Note key)
        {
            _key = key;
            Notes = new List<Note>();
            NotesSet = new HashSet<Note>();
        }

        public void AddNote(Note note)
        {
            Notes.Add(note);
            NotesSet.Add(note);
        }
    }
}