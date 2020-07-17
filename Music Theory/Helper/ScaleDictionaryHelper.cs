using System.Collections.Generic;
using Keyify.Music_Theory.Helper;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using static KeyifyClassLibrary.Core.MusicTheory.ScaleModeDictionary;

namespace KeyifyClassLibrary.Core.MusicTheory.Helper
{
    public static class ScaleDictionaryHelper
    {
        public static List<ScaleDictionaryEntry> GenerateDictionary()
        {
            var dictionary = new List<ScaleDictionaryEntry>();

            foreach (var mode in EnumHelper.GetAllModeNames())
            {
                foreach (var note in EnumHelper.GetAllNoteNames())
                {
                    string scaleLabel = note + " " + mode;

                    Note realNote = NoteHelper.ConvertStringNoteToNoteType(note);
                    Mode realMode = ModeHelper.ConvertStringModeNameToModeType(mode);

                    ScaleDirectoryEntry scaleDirectory = GetScaleDirectory(realMode);

                    ScaleStep[] scaleSteps = scaleDirectory.ScaleSteps;

                    dictionary.Add(new ScaleDictionaryEntry(scaleLabel, ScaleHelper.GenerateScaleFromKey(realNote, scaleSteps)));
                }
            }

            return dictionary;
        }

        public static ScaleDictionaryEntry GenerateEntryFromString(string inputScale)
        {
            inputScale = ScaleMatchHelper.ConvertUserFriendlyLabelIntoLabel(inputScale);

            string note = inputScale.Substring(0, inputScale.IndexOf(' '));
            string mode = inputScale.Substring(inputScale.IndexOf(' '), inputScale.Length - (note.Length));

            if (note.Length > 1)
                if (note[1] == '#')
                    note = NoteHelper.ConvertSharpNoteStringToFlatNote(note).ToString();

            Note realNote = NoteHelper.ConvertStringNoteToNoteType(note);
            ScaleDirectoryEntry realScale = GetScaleDirectory(ModeHelper.ConvertStringModeNameToModeType(mode));
            Scale generatedScale = ScaleHelper.GenerateScaleFromKey(realNote, realScale.ScaleSteps);

            return new ScaleDictionaryEntry(inputScale, generatedScale);
        }
    }
}