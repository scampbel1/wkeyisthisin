using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    //"A mode is what math calls a set, a scale is what math calls a sequence."

    //"A mode is a collection of pitches/pitch classes - that are NOT in a prescribed order"
    //"A pitch/pitch class is a note A, A#, B..."
    //"A scale is an ordered sequence of pitches/pitch classes"
    /*
     "The major scale, harmonic minor scale, and melodic minor scale each have seven different modes.
     The ones for the major scale are commonly used enough to have special names - ionian, dorian, and so on."
    */

    //Rename "Heptatonic"
    public static class HeptatonicScaleModeDictionary
    {
        private static List<Tuple<HeptatonicModes, ScaleStep[]>> GenerateDictionary()
        {
            var scaleDictionary = new List<Tuple<HeptatonicModes, ScaleStep[]>>();

            #region Scales

            //Major Scale

            scaleDictionary.Add(new Tuple<HeptatonicModes, ScaleStep[]>(
                HeptatonicModes.Ionian,
                new ScaleStep[] {
                    ScaleStep.R,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h
                }));

            //Minor Scale

            scaleDictionary.Add(new Tuple<HeptatonicModes, ScaleStep[]>(
                HeptatonicModes.Aeolian,
                new ScaleStep[] {
                    ScaleStep.R,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W
                }));

            scaleDictionary.Add(new Tuple<HeptatonicModes, ScaleStep[]>(
                HeptatonicModes.Phrygian,
                new ScaleStep[]
                {
                    ScaleStep.R,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W
                }));

            scaleDictionary.Add(new Tuple<HeptatonicModes, ScaleStep[]>(
                HeptatonicModes.Lydian,
                new ScaleStep[]
                {
                    ScaleStep.R,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h
                }));

            scaleDictionary.Add(new Tuple<HeptatonicModes, ScaleStep[]>(
                HeptatonicModes.Mixolydian,
                new ScaleStep[]
                {
                    ScaleStep.R,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W
                }));

            scaleDictionary.Add(new Tuple<HeptatonicModes, ScaleStep[]>(
                HeptatonicModes.Locrian,
                new ScaleStep[]
                {
                    ScaleStep.R,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.W
                }));

            scaleDictionary.Add(new Tuple<HeptatonicModes, ScaleStep[]>(
                HeptatonicModes.Dorian,
                new ScaleStep[]
                {
                    ScaleStep.R,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W
                }));

            scaleDictionary.Add(new Tuple<HeptatonicModes, ScaleStep[]>(
                HeptatonicModes.Harmonic_Minor,
                new ScaleStep[]
                {
                    ScaleStep.R,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.Wh,
                    ScaleStep.h
                }));

            scaleDictionary.Add(new Tuple<HeptatonicModes, ScaleStep[]>(
                HeptatonicModes.Melodic_Minor,
                new ScaleStep[]
                {
                    ScaleStep.R,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h
                }));

            scaleDictionary.Add(new Tuple<HeptatonicModes, ScaleStep[]>(
                HeptatonicModes.Augmented, //(W+h) h (W+h) h (W+h) h 
                new ScaleStep[]
                {
                    ScaleStep.R,
                    ScaleStep.Wh,
                    ScaleStep.h,
                    ScaleStep.Wh,
                    ScaleStep.h,
                    ScaleStep.Wh,
                    ScaleStep.h
                }));

            #endregion

            return scaleDictionary;
        }

        public static Tuple<HeptatonicModes, ScaleStep[]> GetScaleDirectory(HeptatonicModes mode)
        {
            return GenerateDictionary().FirstOrDefault(s => s.Item1 == mode);
        }

        public static int ReturnCount()
        {
            return GenerateDictionary().Count;
        }
    }
}

// Music of the common practice periods(1600–1900) uses three types of scale:
// The diatonic scale(seven notes)—this includes the major scale
// and the natural minor
// The melodic and harmonic minor scales(seven notes)        


// Mode Also known as 	Tonic relative to major scale Interval sequence Example
// Ionian      Major scale I            T-T-s-T-T-T-s    C-D-E-F-G-A-B-C
// Dorian      II                       T-s-T-T-T-s-T    D-E-F-G-A-B-C-D
// Phrygian    III                      s-T-T-T-s-T-T    E-F-G-A-B-C-D-E
// Lydian      IV                       T-T-T-s-T-T-s    F-G-A-B-C-D-E-F
// Mixolydian  Dominant scale  V        T-T-s-T-T-s-T    G-A-B-C-D-E-F-G
// Aeolian     Natural minor scale VI   T-s-T-T-s-T-T    A-B-C-D-E-F-G-A
// Locrian     VII                      s-T-T-s-T-T-T    B-C-D-E-F-G-A-B


// Octatonic(8 notes per octave): used in jazz and modern classical music
// Heptatonic(7 notes per octave): the most common modern Western scale
// Hexatonic(6 notes per octave): common in Western folk music
// Pentatonic(5 notes per octave): the anhemitonic form(lacking semitones) is common in folk music, especially in oriental music; also known as the "black note" scale
// Tetratonic(4 notes), tritonic(3 notes), and ditonic(2 notes): generally limited to prehistoric("primitive") music
// Monotonic(1 note): limited use in liturgy, and for effect in modern art music[citation needed]