using System;
using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.MusicTheory.Helper;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
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
                            KeyifyElementStringConverter.ConvertStringNoteToNoteType(note),
                            HeptatonicScaleModeDictionary.GetScaleDirectory(KeyifyElementStringConverter.ConvertStringModeNameToModeType(mode))
                                .ScaleSteps)));
                }
            }

            return dictionary;
        }

        public static ScaleDictionyEntry GenerateEntryFromString(string inputScale)
        {
            Scale generatedScale = ScaleNoteGenerator.GenerateNotes(
                KeyifyElementStringConverter.ConvertStringNoteToNoteType(inputScale[0]),
                HeptatonicScaleModeDictionary.GetScaleDirectory(KeyifyElementStringConverter.ConvertStringModeNameToModeType(inputScale.Substring(2)))
                .ScaleSteps);

            return new ScaleDictionyEntry(inputScale, generatedScale);
        }
    }
}