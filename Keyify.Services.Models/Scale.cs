using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Models
{
    public class GeneratedScale
    {
        public readonly Note RootNote;
        public readonly List<Note> Notes;
        public readonly HashSet<Note> NoteSet;
        public readonly HashSet<string> NoteSetSharp;
        public readonly ModeDefinition ModeDefinition;

        public GeneratedScale(Note key, ModeDefinition modeDefinition)
        {
            RootNote = key;
            Notes = new List<Note>();
            NoteSet = new HashSet<Note>();
            NoteSetSharp = new HashSet<string>();
            ModeDefinition = modeDefinition;

            GenerateScale();
        }

        private void AddNote(Note note)
        {
            Notes.Add(note);
            NoteSet.Add(note);
        }

        private void GenerateScale()
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