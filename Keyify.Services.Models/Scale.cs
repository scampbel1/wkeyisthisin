using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Models
{
    public class GeneratedScale
    {
        public readonly Note RootNote;
        public readonly string SharpRootNote;
        public readonly List<Note> Notes;
        public readonly HashSet<Note> NoteSet;
        public readonly HashSet<string> NoteSetSharp;
        public readonly string Name;
        public readonly string[] ScaleDegrees;
        public readonly string FlatColloquialism;
        public readonly string SharpColloquialism;
        public readonly int Popularity;

        public bool IsKey => Name == "Ionian" || Name == "Aeolian";

        public GeneratedScale(
            Note rootNote,
            string rootNoteSharp,
            List<Note> notes,
            List<string> noteSetSharp,
            string name,
            string[] scaleDegrees,
            int popularity = 3)
        {
            RootNote = rootNote;
            SharpRootNote = rootNoteSharp;
            Notes = notes;
            NoteSet = notes.ToHashSet();
            NoteSetSharp = noteSetSharp.ToHashSet();
            Name = name;
            ScaleDegrees = scaleDegrees;

            FlatColloquialism = GetScaleColloquialism(
                SharpRootNote,
                RootNote,
                Name,
                convertFlatNoteToSharp: false);

            SharpColloquialism = GetScaleColloquialism(
                SharpRootNote,
                RootNote,
                Name,
                convertFlatNoteToSharp: true);

            Popularity = popularity;
        }

        private string GetScaleColloquialism(string sharpRootNote, Note rootNote, string name, bool convertFlatNoteToSharp)
        {
            var note = convertFlatNoteToSharp ?
                sharpRootNote :
                rootNote.ToString();

            var modeEquivalent = GetModeNameColloquialism(name);

            return !string.IsNullOrWhiteSpace(modeEquivalent) ?
                $"{note} {modeEquivalent}" :
                modeEquivalent;

            string GetModeNameColloquialism(string name)
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
}