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
        public readonly HashSet<string> NoteSetSharp;
        public readonly ModeDefinition ModeDefinition;

        public string ColloquialismFlat => GetScaleColloquialism(convertToSharp: false);
        public string ColloquialismSharp => GetScaleColloquialism(convertToSharp: true);

        public Scale(Note key, ModeDefinition modeDefinition)
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
            NoteSetSharp.Add(NoteHelper.ConvertNoteToStringEquivalent(note, true));
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

        private string GetScaleColloquialism(bool convertToSharp)
        {
            var pentatonicModeEquivalent = GetModeNameColloquialismModeLabel(ModeDefinition.Mode);

            return !string.IsNullOrWhiteSpace(pentatonicModeEquivalent) ? $"{NoteHelper.ConvertNoteToStringEquivalent(RootNote, convertToSharp)} {pentatonicModeEquivalent}" : pentatonicModeEquivalent;
        }

        private string GetModeNameColloquialismModeLabel(Mode mode)
        {
            return GetModeNameColloquialism(mode).ToString();
        }

        private ModeColloquialism? GetModeNameColloquialism(Mode mode)
        {
            switch (mode)
            {
                case Mode.Ionian:
                    return ModeColloquialism.Major;
                case Mode.Aeolian:
                    return ModeColloquialism.Minor;
                default:
                    return null;
            }
        }
    }
}