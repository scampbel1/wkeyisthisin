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


        public GeneratedScale(Note rootNote, string rootNoteSharp, List<Note> notes, List<string> noteSetSharp, Mode mode, string[] scaleDegrees)
        {
            RootNote = rootNote;
            SharpRootNote = rootNoteSharp;
            Notes = notes;
            NoteSet = notes.ToHashSet();
            NoteSetSharp = noteSetSharp.ToHashSet();
            Mode = mode;
            ScaleDegrees = scaleDegrees;

            IsKey = (mode == Mode.Ionian || mode == Mode.Aeolian);
        }
    }
}