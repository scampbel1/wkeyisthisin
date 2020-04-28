using System.Collections.Generic;
using KeyifyClassLibrary.Core.MusicTheory.Helper;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public static class ScaleDictionary
    {
        public static List<ScaleDictionyEntry> GenerateDictionary()
        {
            var dictionary = new List<ScaleDictionyEntry>();

            foreach (var mode in EnumValuesConverter.GetModes())
            {
                foreach (var note in EnumValuesConverter.GetNotes())
                {
                    dictionary.Add(new ScaleDictionyEntry(
                        note + " " + mode,

                        ScaleNoteGenerator.GenerateNotes(
                            ElementStringConverter.ConvertStringNoteToNoteType(note),
                            HeptatonicScaleModeDictionary.GetScaleDirectory(ElementStringConverter.ConvertStringModeNameToModeType(mode))
                                .ScaleSteps)));
                }
            }

            return dictionary;
        }

        public static ScaleDictionyEntry GenerateEntryFromString(string inputScale)
        {
            Scale generatedScale = ScaleNoteGenerator.GenerateNotes(
                ElementStringConverter.ConvertStringNoteToNoteType(inputScale[0]),
                HeptatonicScaleModeDictionary.GetScaleDirectory(ElementStringConverter.ConvertStringModeNameToModeType(inputScale.Substring(2)))
                .ScaleSteps);

            return new ScaleDictionyEntry(inputScale, generatedScale);
        }
    }
}