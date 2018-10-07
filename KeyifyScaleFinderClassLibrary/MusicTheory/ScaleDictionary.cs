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
                            KeyifyElementStringConverter
                                .ConvertStringNoteToNoteType(note),

                            HeptatonicScaleModeDictionary
                                .GetScaleDirectory(KeyifyElementStringConverter
                                    .ConvertStringModeNameToModeType(mode))
                                .ScaleSteps)));
                }
            }

            return dictionary;
        }

        public static ScaleDictionyEntry GenerateEntryFromString(string scale)
        {
            return new ScaleDictionyEntry(scale,

                ScaleNoteGenerator
                    .GenerateNotes(
                        KeyifyElementStringConverter
                            .ConvertStringNoteToNoteType(scale[0]),

                        HeptatonicScaleModeDictionary
                            .GetScaleDirectory(
                                KeyifyElementStringConverter
                                    .ConvertStringModeNameToModeType(scale
                                        .Substring(2)))
                            .ScaleSteps));
        }
    }

    public class ScaleDictionyEntry
    {
        public string ScaleName { get; set; }
        public Scale Scale { get; set; }

        public ScaleDictionyEntry(string name, Scale scale)
        {
            ScaleName = name;
            Scale = scale;
        }
    }
}