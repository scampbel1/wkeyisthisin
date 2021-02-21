using Keyify;
using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;

namespace KeyifyClassLibrary.Core.Domain
{
    public class Scale
    {
        public readonly Note RootNote;
        public readonly List<Note> Notes;
        public readonly HashSet<Note> NoteSet;
        public readonly ModeDefinition ModeDefinition;

        public Scale(Note key, ModeDefinition modeDefinition)
        {
            RootNote = key;
            Notes = new List<Note>();
            NoteSet = new HashSet<Note>();
            ModeDefinition = modeDefinition;

            GenerateScale();
        }

        private void AddNote(Note note)
        {
            Notes.Add(note);
            NoteSet.Add(note);
        }

        public void GenerateScale()
        {
            int noteNumber = (int)RootNote;

            foreach (var scaleStep in ModeDefinition.ScaleSteps)
            {
                noteNumber += (int)scaleStep;

                if (noteNumber > 11)
                    noteNumber -= 12;

                AddNote((Note)noteNumber);
            }
        }
    }
}