using System.Collections.Generic;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public class Scale : IScale
    {
        private readonly Note _key;
        public List<Note> Notes { get; set; }

        public Note GetKey()
        {
            return _key;
        }

        public Scale(Note key)
        {
            _key = key;
            Notes = new List<Note>();
        }

        public void AddNote(Note note)
        {
            Notes.Add(note);
        }
    }
}