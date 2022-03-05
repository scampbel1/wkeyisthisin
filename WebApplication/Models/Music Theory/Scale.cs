using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using System.Collections.Generic;

namespace KeyifyClassLibrary.Models.MusicTheory
{
    public class Scale
    {
        public readonly Note RootNote;
        public readonly List<Note> Notes;
        public readonly HashSet<Note> NoteSet;
        public readonly List<string> Notes_Sharp;
        public readonly ModeDefinition ModeDefinition;

        public Scale(Note key, ModeDefinition modeDefinition)
        {
            RootNote = key;
            Notes = new List<Note>();
            NoteSet = new HashSet<Note>();
            Notes_Sharp = new List<string>();
            ModeDefinition = modeDefinition;

            GenerateScale();
        }

        private void AddNote(Note note)
        {
            Notes.Add(note);
            NoteSet.Add(note);
            Notes_Sharp.Add(NoteHelper.ConvertNoteToStringEquivalent(note, true));
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