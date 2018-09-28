using System;
using System.Collections.Generic;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public static class ScaleDictionary
    {
        public static List<Tuple<string, Scale>> GenerateDictionary()
        {
            var dictionary = new List<Tuple<string, Scale>>();

            foreach (var mode in EnumValuesConverter.GetModes())
            {
                foreach (var note in EnumValuesConverter.GetNotes())
                {
                    dictionary.Add(new Tuple<string, Scale>(
                        note + " " + mode,

                        ScaleNoteGenerator.GenerateNotes(
                            KeyifyElementStringConverter
                                .ConvertStringNoteToNoteType(note),

                            HeptatonicScaleModeDictionary
                                .GetScaleDirectory(KeyifyElementStringConverter
                                    .ConvertStringModeNameToModeType(mode))
                                .Item2)
                    ));
                }
            }

            return dictionary;
        }

        public static Tuple<string, Scale> GenerateEntryFromString(string scale)
        {
            return new Tuple<string, Scale>(scale,

                ScaleNoteGenerator
                    .GenerateNotes(
                        KeyifyElementStringConverter
                            .ConvertStringNoteToNoteType(scale[0]),

                        HeptatonicScaleModeDictionary
                            .GetScaleDirectory(
                                KeyifyElementStringConverter
                                    .ConvertStringModeNameToModeType(scale
                                        .Substring(2).ToString()))
                            .Item2

                    ));
        }
    }
}