using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public class TriadFactory : AbstractTriadFactory //TODO: Merge with Mode Class
    {
        public override TriadType[] ReturnTriadSteps(HeptatonicModes mode)
        {
            switch (mode)
            {
                #region Modes
                case HeptatonicModes.Mixolydian:
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

                case HeptatonicModes.Dorian:
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

                case HeptatonicModes.Aeolian:
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

                case HeptatonicModes.Locrian:
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

                case HeptatonicModes.Lydian:
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

                case HeptatonicModes.Phrygian:
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

                case HeptatonicModes.Ionian:
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

                case HeptatonicModes.Harmonic_Minor:
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

                case HeptatonicModes.Melodic_Minor:
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

                case HeptatonicModes.Augmented:
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

        public List<string> GenerateChords(HeptatonicModes mode, Note key) //TODO: Create chord class type
        {
            var notes = ScaleNoteGenerator.GenerateNotes(key,
                HeptatonicScaleModeDictionary.GetScaleDirectory(mode).Item2).Notes;

            int scaleCount = 0; //TODO: Create roman numeral equivalent
            var chords = new List<string>();

            foreach (TriadType tt in ReturnTriadSteps(mode))
            {
                chords.Add(TriadNotationCleanup(string.Format("{0}{1}", notes[scaleCount], tt)));
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