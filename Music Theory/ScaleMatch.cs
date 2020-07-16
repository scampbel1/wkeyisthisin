using KeyifyClassLibrary.Core.MusicTheory.Enums;
using System.Collections.Generic;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public class ScaleMatch
    {
        public string ScaleName { get; set; }
        public List<Note> Scale { get; private set; }
        public bool Selected { get; set; }

        public ScaleMatch()
        {
            Scale = new List<Note>();
        }

        public ScaleMatch(string scaleName, List<Note> notes) : this()
        {
            ScaleName = scaleName;
            Scale = notes;
        }

        public ScaleMatch(string scaleName, Note note) : this()
        {
            ScaleName = scaleName;
            Scale.Add(note);
        }

        public void AddNote(Note note)
        {
            Scale.Add(note);
        }
    }
}
