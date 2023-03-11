using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Models
{
    public class GeneratedScale
    {
        public readonly bool IsKey;
        public readonly Note RootNote;
        public readonly string SharpRootNote;
        public readonly List<Note> Notes;
        public readonly HashSet<Note> NotesHashSet;
        public readonly HashSet<string> SharpNotesHashSet;
        public readonly string Name;
        public readonly string[] ScaleDegrees;
        public readonly string FlatColloquialism;
        public readonly string SharpColloquialism;

        public GeneratedScale(Note rootNote, string rootNoteSharp, List<Note> notes, List<string> noteSetSharp, string name, string[] scaleDegrees)
        {
            RootNote = rootNote;
            SharpRootNote = rootNoteSharp;
            Notes = notes;
            NotesHashSet = notes.ToHashSet();
            SharpNotesHashSet = noteSetSharp.ToHashSet();
            Name = name;
            ScaleDegrees = scaleDegrees;
            FlatColloquialism = GetScaleColloquialism(SharpRootNote, RootNote, Name, convertFlatNoteToSharp: false);
            SharpColloquialism = GetScaleColloquialism(SharpRootNote, RootNote, Name, convertFlatNoteToSharp: true);

            //TODO: This needs to be moved to the DB
            //TODO: Create flag for parallel "scales"
            IsKey = (name == "Ionian" || name == "Aeolian" || name == "Major/Minor (Parallel)" || name == "Minor/Major (Parallel)");
        }

        private string GetScaleColloquialism(string sharpRootNote, Note rootNote, string name, bool convertFlatNoteToSharp)
        {
            var note = convertFlatNoteToSharp ? sharpRootNote : rootNote.ToString();

            var modeEquivalent = GetModeNameColloquialism(name);

            return !string.IsNullOrWhiteSpace(modeEquivalent) ? $"{note} {modeEquivalent}" : modeEquivalent;
        }

        private string GetModeNameColloquialism(string name)
        {
            switch (name)
            {
                case "Ionian":
                    return ModeColloquialism.Major.ToString();
                case "Aeolian":
                    return ModeColloquialism.Minor.ToString();
                default:
                    return string.Empty;
            }
        }
    }
}