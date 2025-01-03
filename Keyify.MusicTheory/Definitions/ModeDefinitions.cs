﻿using Keyify.MusicTheory.Enums;

namespace Keyify.MusicTheory.Definitions
{
    public static class ModeDefinitions
    {
        public static Dictionary<Mode, Interval[]> GetScaleIntervals()
        {
            var scaleIntervals = new Dictionary<Mode, Interval[]>
            {
                { Mode.Ionian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W, Interval.h } },
                { Mode.Aeolian, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W } },
                { Mode.Phrygian, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W } },
                { Mode.Lydian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h } },
                { Mode.Mixolydian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W } },
                { Mode.Locrian, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W } },
                { Mode.Dorian, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W } },
                { Mode.HarmonicMinor, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.Wh, Interval.h } },
                { Mode.MelodicMinor, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W, Interval.W, Interval.h } },
                { Mode.Augmented, new Interval[] { Interval.R, Interval.Wh, Interval.h, Interval.Wh, Interval.h, Interval.Wh, Interval.h } },
                { Mode.MinorPentatonic, new Interval[] { Interval.R, Interval.Wh, Interval.W, Interval.W, Interval.Wh, Interval.W } },
                { Mode.MajorPentatonic, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.Wh, Interval.W, Interval.Wh } },
                { Mode.Blues, new Interval[] { Interval.R, Interval.Wh, Interval.W, Interval.h, Interval.h, Interval.Wh, Interval.W } },
                { Mode.WholeTone, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W } },
                { Mode.DiminishedWholeHalf, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h } },
                { Mode.DiminishedHalfWhole, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W } },
                { Mode.Arabian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.h, Interval.W, Interval.W, Interval.W } },
                { Mode.AugmentedLydian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h } },
                { Mode.Byzantine, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.h, Interval.W, Interval.h, Interval.Wh, Interval.h } },
                { Mode.Egyptian, new Interval[] { Interval.R, Interval.W, Interval.Wh, Interval.W, Interval.Wh, Interval.W } },
                { Mode.HungarianMajor, new Interval[] { Interval.R, Interval.Wh, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W } },
                { Mode.NeopolitanMajor, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W, Interval.h } },
                { Mode.BalinesePelog, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.WW, Interval.h, Interval.WW } },
                { Mode.Prometheus, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.Wh, Interval.h, Interval.W } },
                { Mode.SixToneSymmetrical, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.h, Interval.Wh, Interval.h, Interval.Wh } },
                { Mode.Altered, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W, Interval.W } },
                { Mode.Chinese, new Interval[] { Interval.R, Interval.WW, Interval.W, Interval.h, Interval.WW, Interval.h } },
                { Mode.DiminishedLydian, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.Wh, Interval.h, Interval.W, Interval.W, Interval.h } },
                { Mode.EightToneSpanish, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.h, Interval.h, Interval.W, Interval.W, Interval.W } },
                { Mode.HungarianMinor, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.Wh, Interval.h, Interval.h, Interval.Wh, Interval.h } },
                { Mode.Kumoi, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.WW, Interval.W, Interval.Wh } },
                { Mode.Locrian2, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W } },
                { Mode.Lydian9, new Interval[] { Interval.R, Interval.Wh, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h } },
                { Mode.MinorLydian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.h, Interval.h, Interval.W, Interval.W } },
                { Mode.MixolydianB6, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W } },
                { Mode.Hindu, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W } },
                { Mode.Persian, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.h, Interval.h, Interval.W, Interval.Wh, Interval.h } },
                { Mode.PrometheusNeopolitan, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.W, Interval.Wh, Interval.h, Interval.W } },
                { Mode.TodiTheta, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.Wh, Interval.h, Interval.h, Interval.Wh, Interval.h } },
                { Mode.AlteredBb7, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.Wh } },
                { Mode.AugmentedIonian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.Wh, Interval.h, Interval.W, Interval.h } },
                { Mode.Enigmatic, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.W, Interval.W, Interval.W, Interval.h, Interval.h } },
                { Mode.Hirajoshi, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.WW, Interval.h, Interval.WW } },
                { Mode.Ichikosucho, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.h, Interval.h, Interval.W, Interval.W, Interval.h } },
                { Mode.LeadingWholeTone, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W, Interval.h, Interval.h } },
                { Mode.LydianB7, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W } },
                { Mode.Overtone, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W } },
                { Mode.MajorPhrygian, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W } },
                { Mode.Neopolitan, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.W, Interval.h, Interval.Wh, Interval.h } },
                { Mode.PurviTheta, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.W, Interval.h, Interval.h, Interval.Wh, Interval.h } },
                { Mode.DorianB2, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W } },
    
                // Modes Derived from Harmonic Minor
                { Mode.LocrianSharp6, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W, Interval.Wh, Interval.h } },
                { Mode.IonianSharp5, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.W, Interval.Wh, Interval.Wh, Interval.h } },
                { Mode.DorianSharp4, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.Wh, Interval.Wh, Interval.Wh, Interval.h } },
                { Mode.PhrygianDominant, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.W, Interval.h, Interval.W, Interval.h, Interval.Wh } },
                { Mode.LydianSharp2, new Interval[] { Interval.R, Interval.Wh, Interval.Wh, Interval.h, Interval.W, Interval.Wh, Interval.W, Interval.h } },

                // Modes Derived from Melodic Minor
                { Mode.PhrygianNatural6, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W, Interval.h } },
                { Mode.LydianAugmented, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W, Interval.h } },
                { Mode.LydianDominant, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h } },
                { Mode.MixolydianFlat6, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W } },
                { Mode.LocrianNatural2, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W } },

                // Middle Eastern Maqam
                { Mode.Rast, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.Wh, Interval.h } },
                { Mode.Bayati, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h } },
                { Mode.Hijaz, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.h, Interval.Wh, Interval.W, Interval.W, Interval.h } },
                { Mode.Nahawand, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.Wh, Interval.h } },
                { Mode.Kurd, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W } },
                { Mode.Saba, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h, Interval.Wh, Interval.h } },
                { Mode.Ajam, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W } },

                // Chinese Pentatonic Variants
                { Mode.Shang, new Interval[] { Interval.R, Interval.W, Interval.Wh, Interval.W, Interval.Wh } },
                { Mode.Jiao, new Interval[] { Interval.R, Interval.W, Interval.Wh, Interval.W, Interval.Wh } },
                { Mode.Zhi, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.Wh, Interval.W } },
                { Mode.Yu, new Interval[] { Interval.R, Interval.W, Interval.Wh, Interval.W, Interval.Wh } },


                // Japanese Scales
                { Mode.Yo, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.Wh, Interval.W } },
                { Mode.Iwato, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.W } },
                { Mode.Kokinjoshi, new Interval[] { Interval.R, Interval.W, Interval.Wh, Interval.W, Interval.Wh, Interval.h, Interval.W } },

                //{ Mode.Kokinjoshi, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W } }
            };

            return scaleIntervals;
        }

        public static Dictionary<Mode, string[]> GetScaleDegrees()
        {
            var scaleDegrees = new Dictionary<Mode, string[]>
            {
                { Mode.Ionian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.Aeolian, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Phrygian, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Lydian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.Mixolydian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Locrian, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Dorian, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.HarmonicMinor, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth } },
                { Mode.MelodicMinor, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.Augmented, new string[] { Degree.First, Degree.FlatThird, Degree.Third, Degree.Fifth, Degree.SharpFifth, Degree.Seventh, Degree.Eighth } },
                { Mode.MinorPentatonic, new string[] { Degree.First, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.MajorPentatonic, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fifth, Degree.Sixth, Degree.Eighth } },
                { Mode.Blues, new string[] { Degree.First, Degree.FlatThird, Degree.Fourth, Degree.SharpFourth, Degree.Fifth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.WholeTone, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.SharpFifth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.DiminishedWholeHalf, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.DiminishedHalfWhole, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.FlatFourth, Degree.FlatFifth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Arabian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.SharpFourth, Degree.SharpFifth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.AugmentedLydian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.SharpFifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.Byzantine, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth } },
                { Mode.Egyptian, new string[] { Degree.First, Degree.Second, Degree.Fourth, Degree.Fifth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.HungarianMajor, new string[] { Degree.First, Degree.SharpSecond, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.NeopolitanMajor, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.BalinesePelog, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fifth, Degree.FlatSixth, Degree.Eighth } },
                { Mode.Prometheus, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.FlatFifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.SixToneSymmetrical, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.Fourth, Degree.SharpFifth, Degree.Sixth, Degree.Eighth } },
                { Mode.Altered, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.FlatFourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Chinese, new string[] { Degree.First, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Seventh, Degree.Eighth } },
                { Mode.DiminishedLydian, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.EightToneSpanish, new string[] { Degree.First, Degree.FlatSecond, Degree.SharpSecond, Degree.Third, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.HungarianMinor, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.SharpFourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth } },
                { Mode.Kumoi, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.Sixth, Degree.Eighth } },
                { Mode.Locrian2, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Lydian9, new string[] { Degree.First, Degree.SharpSecond, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.MinorLydian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.MixolydianB6, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Hindu, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Persian, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth } },
                { Mode.PrometheusNeopolitan, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.FlatFifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.TodiTheta, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.SharpFourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth } },
                { Mode.AlteredBb7, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.FlatFourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatFlatSeventh, Degree.Eighth } },
                { Mode.AugmentedIonian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.SharpFifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.Enigmatic, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.SharpFourth, Degree.SharpFifth, Degree.SharpSixth, Degree.Seventh, Degree.Eighth } },
                { Mode.Hirajoshi, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.FlatSixth, Degree.Eighth } },
                { Mode.Ichikosucho, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.LeadingWholeTone, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.SharpFifth, Degree.SharpSixth, Degree.Seventh, Degree.Eighth } },
                { Mode.LydianB7, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Overtone, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.MajorPhrygian, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Neopolitan, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth } },
                { Mode.PurviTheta, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth } },
                { Mode.DorianB2, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },

                // Modes Derived from Harmonic Minor
                { Mode.LocrianSharp6, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.FlatFifth, Degree.SharpSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.IonianSharp5, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.SharpFifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.DorianSharp4, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.PhrygianDominant, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.LydianSharp2, new string[] { Degree.First, Degree.SharpSecond, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },

                // Modes Derived from Melodic Minor
                { Mode.PhrygianNatural6, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.LydianAugmented, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.SharpFifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },
                { Mode.LydianDominant, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.MixolydianFlat6, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.LocrianNatural2, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },

                // Middle Eastern Maqam
                { Mode.Rast, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh } },
                { Mode.Bayati, new string[] { Degree.First, Degree.FlatSecond, Degree.Second, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Hijaz, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Nahawand, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Kurd, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Saba, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth } },
                { Mode.Ajam, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth } },

                // Chinese Pentatonic Variants
                { Mode.Shang, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fifth, Degree.Sixth } },
                { Mode.Jiao, new string[] { Degree.First, Degree.Second, Degree.Fourth, Degree.Fifth, Degree.Sixth } },
                { Mode.Zhi, new string[] { Degree.First, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.Seventh } },
                { Mode.Yu, new string[] { Degree.First, Degree.Third, Degree.Fourth, Degree.Sixth, Degree.Seventh } },

                // Japanese Scales
                { Mode.Yo, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fifth, Degree.Sixth } },
                { Mode.Iwato, new string[] { Degree.First, Degree.FlatSecond, Degree.Fourth, Degree.FlatFifth, Degree.FlatSeventh } },
                { Mode.Kokinjoshi, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } },
                //{ Mode.Kokinjoshi, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth } }
            };

            return scaleDegrees;
        }

        /// <summary>
        /// Some scales have a limited array of root notes
        /// </summary>
        /// <returns></returns>
        public static Dictionary<Mode, Note[]> GetExplicitRootNoteScaleRootNotes()
        {
            var explicitRootNoteScaleRootNotes = new Dictionary<Mode, Note[]>
            {
                { Mode.WholeTone, new[] { Note.D, Note.F } },
                { Mode.DiminishedWholeHalf, new[] { Note.C, Note.Db, Note.D } },
                { Mode.DiminishedHalfWhole, new[] { Note.C, Note.Db, Note.D } }
            };

            return explicitRootNoteScaleRootNotes;
        }
    }
}
