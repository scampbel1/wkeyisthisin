using System;
using System.Collections.Generic;
using System.Linq;
using KeyifyClassLibrary.Core.MusicTheory;
using KeyifyClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyClassLibrary.MusicTheory
{
    public class ChordGroupingFactory : AbstractChordGroupingFactory //TODO: Merge with Mode Class
    {
        public override TriadType[] ReturnTriadTemplate(HeptatonicMode mode)
        {
            switch (mode)
            {
                #region Modes
                case HeptatonicMode.Mixolydian:
                    return new TriadType[]
                    {
                        TriadType.M,
                        TriadType.m,
                        TriadType.o,
                        TriadType.M,
                        TriadType.m,
                        TriadType.m,
                        TriadType.M
                    };

                case HeptatonicMode.Dorian:
                    return new TriadType[]
                    {
                        TriadType.m,
                        TriadType.m,
                        TriadType.M,
                        TriadType.M,
                        TriadType.m,
                        TriadType.o,
                        TriadType.M
                    };

                case HeptatonicMode.Aeolian:
                    return new TriadType[]
                    {
                        TriadType.m,
                        TriadType.o,
                        TriadType.M,
                        TriadType.m,
                        TriadType.m,
                        TriadType.M,
                        TriadType.M
                    };

                case HeptatonicMode.Locrian:
                    return new TriadType[]
                    {
                        TriadType.o,
                        TriadType.M,
                        TriadType.m,
                        TriadType.m,
                        TriadType.M,
                        TriadType.M,
                        TriadType.m
                    };

                case HeptatonicMode.Lydian:
                    return new TriadType[]
                    {
                        TriadType.M,
                        TriadType.M,
                        TriadType.m,
                        TriadType.o,
                        TriadType.M,
                        TriadType.m,
                        TriadType.m
                    };

                case HeptatonicMode.Phrygian:
                    return new TriadType[]
                    {
                        TriadType.m,
                        TriadType.M,
                        TriadType.M,
                        TriadType.m,
                        TriadType.o,
                        TriadType.M,
                        TriadType.m
                    };

                case HeptatonicMode.Ionian:
                    return new TriadType[]
                    {
                        TriadType.M,
                        TriadType.m,
                        TriadType.m,
                        TriadType.M,
                        TriadType.M,
                        TriadType.m,
                        TriadType.o
                    };

                case HeptatonicMode.HarmonicMinor:
                    return new TriadType[]
                    {
                        TriadType.m,
                        TriadType.o,
                        TriadType.aug,
                        TriadType.m,
                        TriadType.M,
                        TriadType.M,
                        TriadType.o
                    };

                case HeptatonicMode.MelodicMinor:
                    return new TriadType[]
                    {
                        TriadType.m,
                        TriadType.m,
                        TriadType.aug,
                        TriadType.M,
                        TriadType.M,
                        TriadType.o,
                        TriadType.o
                    };

                case HeptatonicMode.Augmented:
                    return new TriadType[]
                    {
                        //TriadType.m,
                        //TriadType.m,
                        //TriadType.aug,
                        //TriadType.M,
                        //TriadType.M,
                        //TriadType.o,
                        TriadType.o
                    };

                //https://music.stackexchange.com/questions/45752/diminished-and-augmented-scales

                #endregion
                default: throw new ArgumentException($"Mode \"{mode}\" Triad Steps not defined");
            }
        }

        public override TriadType[] ReturnTriadTemplate(PentatonicModes mode)
        {
            throw new NotImplementedException();
        }

        public List<string> GenerateChords(HeptatonicMode mode, Note key) //TODO: Create chord class type
        {
            var notes = ScaleNoteGenerator.GenerateNotes(key,
                HeptatonicScaleModeDictionary.GetScaleDirectory(mode).ScaleSteps).Notes;

            int scaleCount = 0; //TODO: Create roman numeral equivalent
            var chords = new List<string>();

            foreach (TriadType tt in ReturnTriadTemplate(mode))
            {
                chords.Add(TriadNotationCleanup($"{notes[scaleCount]}{tt}"));
                scaleCount++;
            }

            return chords;
        }

        private static string TriadNotationCleanup(string triad)
        {
            triad = triad.Contains('M') ? triad.Replace("M", "") : triad;
            triad = triad.Contains("aug") ? triad.Replace("aug", "+") : triad;

            return triad;
        }
    }
}