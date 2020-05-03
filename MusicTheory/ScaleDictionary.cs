using System;
using System.Collections.Generic;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;
using static KeyifyClassLibrary.Core.MusicTheory.ScaleModeDictionary;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public static class ScaleDictionary
    {
        public static List<ScaleDictionaryEntry> GenerateDictionary()
        {
            var dictionary = new List<ScaleDictionaryEntry>();

            foreach (var mode in EnumValuesConverter.GetModes())
            {
                foreach (var note in EnumValuesConverter.GetNotes())
                {
                    string scaleLabel = note + " " + mode;
                    Note realNote = ElementStringConverter.ConvertStringNoteToNoteType(note);
                    Mode realMode = ElementStringConverter.ConvertStringModeNameToModeType(mode);
                    ScaleDirectoryEntry scaleDirectory = GetScaleDirectory(realMode);
                    ScaleStep[] scaleSteps = scaleDirectory.ScaleSteps;

                    dictionary.Add(new ScaleDictionaryEntry(scaleLabel, ScaleNoteGenerator.GenerateNotes(realNote, scaleSteps)));
                }
            }

            return dictionary;
        }

        public static ScaleDictionaryEntry GenerateEntryFromString(string inputScale)
        {
            string note = inputScale.Substring(0, inputScale.IndexOf(' '));
            string mode = inputScale.Substring(inputScale.IndexOf(' '), inputScale.Length - (note.Length));

            if (note.Length > 1)
                if (note[1] == '#')
                    note = ElementStringConverter.ConvertSharpNoteStringToFlat(note).ToString();

            Note realNote = ElementStringConverter.ConvertStringNoteToNoteType(note);
            ScaleDirectoryEntry realScale = GetScaleDirectory(ElementStringConverter.ConvertStringModeNameToModeType(mode));
            Scale generatedScale = ScaleNoteGenerator.GenerateNotes(realNote, realScale.ScaleSteps);

            return new ScaleDictionaryEntry(inputScale, generatedScale);
        }
    }
}