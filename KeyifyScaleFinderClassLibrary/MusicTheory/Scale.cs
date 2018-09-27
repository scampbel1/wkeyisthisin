using System.Collections.Generic;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public class Scale : IScale
    {
        public readonly Note Key;
        public List<Note> Notes { get; private set; }

        public Scale(Note key)
        {
            Notes = new List<Note>();
            this.Key = key;
        }

        public void AddNote(Note note)
        {
            Notes.Add(note);
        }
    }
}