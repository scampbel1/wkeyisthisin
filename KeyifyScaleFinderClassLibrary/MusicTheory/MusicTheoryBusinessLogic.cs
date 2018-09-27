using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public static class ScaleNoteGenerator
    {
        public static Scale GenerateNotes(Note key, ScaleStep[] scaleSteps)
        {
            var scale = new Scale(key);
            var noteNumber = (int)key;

            foreach (var scaleStep in scaleSteps)
            {
                noteNumber += (int)scaleStep;
                if (noteNumber > 11) noteNumber -= 12; //number of notes will never be larger than 12
                scale.AddNote((Note)noteNumber);
            }

            return scale;
        }
    }

    public static class ScaleDictionary
    {
        public static List<Tuple<string, Scale>> GenerateDictionary()
        {
            var dictionary = new List<Tuple<string, Scale>>();

            foreach (string mode in KeyifyGetEnumValues.GetModes())
            {
                foreach (var note in KeyifyGetEnumValues.GetNotes())
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

    public static class ScaleMatcher
    {
        public static List<Tuple<string, List<Note>>> GetMatchedScales(Note[] selectedNotes, int maximumMissing = 0)
        {
            var Scales = ScaleDictionary.GenerateDictionary();
            var matches = new List<Tuple<string, List<Note>>>();

            foreach (Note note in selectedNotes)
            {
                foreach (var scale in Scales)
                {
                    if (scale.Item2.Notes.Contains(note))
                    {
                        if (matches.Any(a => a.Item1 == scale.Item1))
                        {
                            matches.Single(a => a.Item1 == scale.Item1)
                                .Item2.Add(note);
                        }
                        else
                        {
                            matches.Add(new Tuple<string, List<Note>>(scale.Item1, new List<Note>() { note }));
                        }
                    }
                }
            }

            matches.RemoveAll(a => a.Item2.Count < (selectedNotes.Count() - maximumMissing));

            return matches;
        }
    }

    public static class KeyifyElementStringConverter
    {
        public static Note ConvertStringNoteToNoteType(string note)
        {
            return (Note)Enum.Parse(typeof(Note), note, true);
        }

        public static Note ConvertStringNoteToNoteType(char note)
        {
            return (Note)Enum.Parse(typeof(Note), note.ToString(), true);
        }

        public static HeptatonicModes ConvertStringModeNameToModeType(string mode)
        {
            return (HeptatonicModes)Enum.Parse(typeof(HeptatonicModes), mode, true);
        }
    }

    /*https://www.guitarmasterclass.net/guitar_forum/index.php?showtopic=6023
     *https://www.guitarmasterclass.net/guitar_forum/index.php?showtopic=3630
    */

    public static class KeyifyGetEnumValues
    {
        public static List<string> GetNotes()
        {
            return Enum.GetNames(typeof(Note)).ToList();
        }

        public static List<string> GetModes()
        {
            return Enum.GetNames(typeof(HeptatonicModes)).ToList();
        }
    }
}