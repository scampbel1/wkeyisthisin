using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Models.Music_Theory
{
    public class Chord
    {
        public readonly List<Note> Notes = new List<Note>(12);

        public Chord(params Note[] notes)
        {
            Notes.AddRange(notes);
        }
    }
}
