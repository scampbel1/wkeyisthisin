using System.Collections.Generic;
using KeyifyClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public class ScaleMatch
    {
        public string ScaleName { get; set; }
        public List<Note> Scale { get; private set; }

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

        //TODO: Create method to tidy up scale where they're defined as enum constants
//        private string GenerateScaleLabel(string scaleName)
//        {
//            if(scaleName.Contains())
//        }
    }
}
