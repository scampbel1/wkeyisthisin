//using System;
//using System.Collections.Generic;
//using System.Linq;
//using GuitarKeyFinder;

//namespace KeyifyScaleFinderClassLibrary.Theory
//{
//    public static class ScaleNoteGenerator
//    {
//        public static Scale GenerateNotes(Note key, ScaleStep[] scaleSteps)
//        {
//            var scale = new Scale(key);
//            int noteNumber = (int)key;

//            foreach (var scaleStep in scaleSteps)
//            {
//                noteNumber += (int)scaleStep;
//                if (noteNumber > 11) noteNumber -= 12; //number of notes will never be larger than 12
//                scale.AddNote((Note)noteNumber);
//            }

//            return scale;
//        }
//    }

//    public class Scale : IScale
//    {
//        public readonly Note Key;
//        public IEnumerable<Note> Notes { get; set; }

//        public Scale(Note key)
//        {
//            Notes = new List<Note>();
//            this.Key = key;
//        }

//        public void AddNote(Note note)
//        {
//            Notes.ToList().Add(note);
//        }
//    }

//    public static class ScaleDictionary
//    {
//        public static List<Tuple<string, Scale>> GenerateDictionary()
//        {
//            var dictionary = new List<Tuple<string, Scale>>();

//            foreach (string mode in KeyifyGetEnumValues.GetModes())
//            {
//                foreach (var note in KeyifyGetEnumValues.GetNotes())
//                {
//                    dictionary.Add(new Tuple<string, Scale>(
//                    note + " " + mode,

//                        ScaleNoteGenerator.GenerateNotes(
//                            KeyifyElementStringConverter
//                            .ConvertStringNoteToNoteType(note),

//                            HeptatonicScaleModeDictionary
//                            .GetScaleDirectory(KeyifyElementStringConverter
//                            .ConvertStringModeNameToModeType(mode))
//                            .Item2)
//                            ));
//                }
//            }

//            return dictionary;
//        }

//        public static Tuple<string, Scale> GenerateEntryFromString(string scale)
//        {
//            return new Tuple<string, Scale>(scale,

//                ScaleNoteGenerator
//                .GenerateNotes(
//                    KeyifyElementStringConverter
//                .ConvertStringNoteToNoteType(scale[0]),

//                HeptatonicScaleModeDictionary
//                .GetScaleDirectory(
//                    KeyifyElementStringConverter
//                .ConvertStringModeNameToModeType(scale
//                .Substring(2).ToString()))
//                .Item2

//                ));
//        }
//    }

//    //Try and refactor code to avoid Tuple use, and improve readability
//    public struct MatchedScale
//    {
//        public readonly string ScaleName;
//        public readonly IEnumerable<Note> ScaleNotes;
//    }

//    public static class ScaleMatcher
//    {
//        public static List<Tuple<string, List<Note>>> GetMatchedScales(Note[] selectedNotes, int maximumMissing = 0)
//        {
//            var Scales = ScaleDictionary.GenerateDictionary();
//            var matches = new List<Tuple<string, List<Note>>>();

//            foreach (Note note in selectedNotes)
//            {
//                foreach (var scale in Scales)
//                {
//                    if (scale.Item2.Notes.Contains(note))
//                    {
//                        //If scale name is already a part of matches
//                        if (matches.Any(a => a.Item1 == scale.Item1))
//                        {
//                            //TODO: this is confusing - not clear what is going on here
//                            matches.Single(a => a.Item1 == scale.Item1)
//                                .Item2.Add(note);
//                        }
//                        else
//                        {
//                            matches.Add(new Tuple<string, List<Note>>(scale.Item1, new List<Note>() { note }));
//                        }
//                    }
//                }
//            }

//            matches.RemoveAll(a => a.Item2.Count < (selectedNotes.Count() - maximumMissing));

//            return matches;
//        }
//    }

//    public static class KeyifyElementStringConverter
//    {
//        public static Note ConvertStringNoteToNoteType(string note)
//        {
//            return (Note)Enum.Parse(typeof(Note), note, true);
//        }

//        public static Note ConvertStringNoteToNoteType(char note)
//        {
//            return (Note)Enum.Parse(typeof(Note), note.ToString(), true);
//        }

//        public static HeptatonicModes ConvertStringModeNameToModeType(string mode)
//        {
//            return (HeptatonicModes)Enum.Parse(typeof(HeptatonicModes), mode, true);
//        }
//    }

//    /*https://www.guitarmasterclass.net/guitar_forum/index.php?showtopic=6023
//     *https://www.guitarmasterclass.net/guitar_forum/index.php?showtopic=3630
//    */
//    public class Triad : TriadFactory //To-Do: Merge with Mode Class
//    {
//        public override TriadType[] ReturnTriadSteps(HeptatonicModes mode)
//        {
//            switch (mode)
//            {
//                #region Modes
//                case HeptatonicModes.Mixolydian:
//                    return new TriadType[]
//                    {
//                        TriadType.M,
//                        TriadType.m,
//                        TriadType.o,
//                        TriadType.M,
//                        TriadType.m,
//                        TriadType.m,
//                        TriadType.M
//                    };

//                case HeptatonicModes.Dorian:
//                    return new TriadType[]
//                    {
//                        TriadType.m,
//                        TriadType.m,
//                        TriadType.M,
//                        TriadType.M,
//                        TriadType.m,
//                        TriadType.o,
//                        TriadType.M
//                    };

//                case HeptatonicModes.Aeolian:
//                    return new TriadType[]
//                    {
//                        TriadType.m,
//                        TriadType.o,
//                        TriadType.M,
//                        TriadType.m,
//                        TriadType.m,
//                        TriadType.M,
//                        TriadType.M
//                    };

//                case HeptatonicModes.Locrian:
//                    return new TriadType[]
//                    {
//                        TriadType.o,
//                        TriadType.M,
//                        TriadType.m,
//                        TriadType.m,
//                        TriadType.M,
//                        TriadType.M,
//                        TriadType.m
//                    };

//                case HeptatonicModes.Lydian:
//                    return new TriadType[]
//                    {
//                        TriadType.M,
//                        TriadType.M,
//                        TriadType.m,
//                        TriadType.o,
//                        TriadType.M,
//                        TriadType.m,
//                        TriadType.m
//                    };

//                case HeptatonicModes.Phrygian:
//                    return new TriadType[]
//                    {
//                        TriadType.m,
//                        TriadType.M,
//                        TriadType.M,
//                        TriadType.m,
//                        TriadType.o,
//                        TriadType.M,
//                        TriadType.m
//                    };

//                case HeptatonicModes.Ionian:
//                    return new TriadType[]
//                    {
//                        TriadType.M,
//                        TriadType.m,
//                        TriadType.m,
//                        TriadType.M,
//                        TriadType.M,
//                        TriadType.m,
//                        TriadType.o
//                    };

//                case HeptatonicModes.Harmonic_Minor:
//                    return new TriadType[]
//                    {
//                        TriadType.m,
//                        TriadType.o,
//                        TriadType.aug,
//                        TriadType.m,
//                        TriadType.M,
//                        TriadType.M,
//                        TriadType.o
//                    };

//                case HeptatonicModes.Melodic_Minor:
//                    return new TriadType[]
//                    {
//                        TriadType.m,
//                        TriadType.m,
//                        TriadType.aug,
//                        TriadType.M,
//                        TriadType.M,
//                        TriadType.o,
//                        TriadType.o
//                    };

//                case HeptatonicModes.Augmented:
//                    return new TriadType[]
//                    {
//                        //TriadType.m,
//                        //TriadType.m,
//                        //TriadType.aug,
//                        //TriadType.M,
//                        //TriadType.M,
//                        //TriadType.o,
//                        TriadType.o
//                    };

//                //https://music.stackexchange.com/questions/45752/diminished-and-augmented-scales

//                #endregion
//                default: throw new ArgumentException(string.Format("Mode \"{0}\" Triad Steps not defined", mode));
//            }
//        }

//        public List<string> GenerateChords(HeptatonicModes mode, Note key) //To-Do: Create chord class type
//        {
//            var notes = ScaleNoteGenerator.GenerateNotes(key,
//                HeptatonicScaleModeDictionary.GetScaleDirectory(mode).Item2).Notes;

//            int scaleCount = 0; //To-Do: Create roman numeral equivalent
//            var chords = new List<string>();

//            foreach (TriadType tt in ReturnTriadSteps(mode))
//            {
//                chords.Add(RemoveRedundantNotation(string.Format("{0}{1}", notes[scaleCount], tt)));
//                scaleCount++;
//            }

//            return chords;
//        }

//        private static string RemoveRedundantNotation(string triad)
//        {
//            triad = triad.Contains('M') ? triad.Replace("M", "") : triad;
//            triad = triad.Contains("aug") ? triad.Replace("aug", "+") : triad;

//            return triad;
//        }
//    }

//    public static class KeyifyGetEnumValues
//    {
//        public static List<string> GetNotes()
//        {
//            return Enum.GetNames(typeof(Note)).ToList();
//        }

//        public static List<string> GetModes()
//        {
//            return Enum.GetNames(typeof(HeptatonicModes)).ToList();
//        }
//    }
//}
