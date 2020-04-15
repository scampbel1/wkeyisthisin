using System.Collections.Generic;
using KeyifyClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public class Scale : IScale
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