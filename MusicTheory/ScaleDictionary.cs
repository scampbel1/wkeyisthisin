using System.Collections.Generic;
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
            Scale generatedScale = ScaleNoteGenerator.GenerateNotes(
                ElementStringConverter.ConvertStringNoteToNoteType(inputScale[0]),
                HeptatonicScaleModeDictionary.GetScaleDirectory(ElementStringConverter.ConvertStringModeNameToModeType(inputScale.Substring(2)))
                .ScaleSteps);

            return new ScaleDictionaryEntry(inputScale, generatedScale);
        }
    }
}