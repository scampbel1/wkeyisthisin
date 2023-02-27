using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Models
{
    public class GeneratedScale
    {
        public readonly bool IsKey;
        public readonly Note RootNote;
        public readonly string SharpRootNote;
        public readonly List<Note> Notes;
        public readonly HashSet<Note> NoteSet;
        public readonly HashSet<string> NoteSetSharp;
        public readonly Mode Mode;
        public readonly string[] ScaleDegrees;
        public readonly string FlatColloquialism;
        public readonly string SharpColloquialism;

        public GeneratedScale(Note rootNote, string rootNoteSharp, List<Note> notes, List<string> noteSetSharp, Mode mode, string[] scaleDegrees)
        {
            RootNote = rootNote;
            SharpRootNote = rootNoteSharp;
            Notes = notes;
            NoteSet = notes.ToHashSet();
            NoteSetSharp = noteSetSharp.ToHashSet();
            Mode = mode;
            ScaleDegrees = scaleDegrees;
            FlatColloquialism = GetScaleColloquialism(SharpRootNote, RootNote, Mode, convertFlatNoteToSharp: false);
            SharpColloquialism = GetScaleColloquialism(SharpRootNote, RootNote, Mode, convertFlatNoteToSharp: true);

            IsKey = (mode == Mode.Ionian || mode == Mode.Aeolian);
        }

        private string GetScaleColloquialism(string sharpRootNote, Note rootNote, Mode mode, bool convertFlatNoteToSharp)
        {
            var note = convertFlatNoteToSharp ? sharpRootNote : rootNote.ToString();

            var modeEquivalent = GetModeNameColloquialism(mode);

            return !string.IsNullOrWhiteSpace(modeEquivalent) ? $"{note} {modeEquivalent}" : modeEquivalent;
        }

        private string GetModeNameColloquialism(Mode mode)
        {
            switch (mode)
            {
                case Mode.Ionian:
                    return ModeColloquialism.Major.ToString();
                case Mode.Aeolian:
                    return ModeColloquialism.Minor.ToString();
                default:
                    return string.Empty;
            }
        }
    }
}