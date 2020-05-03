using System.Collections.Generic;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;

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
                    dictionary.Add(new ScaleDictionaryEntry(
                        note + " " + mode,

                        ScaleNoteGenerator.GenerateNotes(
                            ElementStringConverter.ConvertStringNoteToNoteType(note),
                            HeptatonicScaleModeDictionary.GetScaleDirectory(ElementStringConverter.ConvertStringModeNameToModeType(mode))
                                .ScaleSteps)));
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

            var realScale = HeptatonicScaleModeDictionary.GetScaleDirectory(ElementStringConverter.ConvertStringModeNameToModeType(mode));

            Scale generatedScale = ScaleNoteGenerator.GenerateNotes(realNote, realScale.ScaleSteps);

            return new ScaleDictionaryEntry(inputScale, generatedScale);
        }
    }
}