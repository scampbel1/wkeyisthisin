using Keyify.MusicTheory.Enums;

namespace Keyify.MusicTheory.Definitions
{
    public static class ScaleDefinitions
    {
        public static Dictionary<Mode, Interval[]> GetScaleIntervals()
        {
            var scaleIntervals = new Dictionary<Mode, Interval[]>();

            scaleIntervals.Add(Mode.Ionian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W, Interval.h });
            scaleIntervals.Add(Mode.Aeolian, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.Phrygian, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.Lydian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h });
            scaleIntervals.Add(Mode.Mixolydian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W });
            scaleIntervals.Add(Mode.Locrian, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.Dorian, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W });
            scaleIntervals.Add(Mode.HarmonicMinor, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.Wh, Interval.h });
            scaleIntervals.Add(Mode.MelodicMinor, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W, Interval.W, Interval.h });
            scaleIntervals.Add(Mode.Augmented, new Interval[] { Interval.R, Interval.Wh, Interval.h, Interval.Wh, Interval.h, Interval.Wh, Interval.h });
            scaleIntervals.Add(Mode.MinorPentatonic, new Interval[] { Interval.R, Interval.Wh, Interval.W, Interval.W, Interval.Wh, Interval.W });
            scaleIntervals.Add(Mode.MajorPentatonic, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.Wh, Interval.W, Interval.Wh });
            scaleIntervals.Add(Mode.Blues, new Interval[] { Interval.R, Interval.Wh, Interval.W, Interval.h, Interval.h, Interval.Wh, Interval.W });
            scaleIntervals.Add(Mode.WholeTone, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.DiminishedWholeHalf, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h });
            scaleIntervals.Add(Mode.DiminishedHalfWhole, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W });
            scaleIntervals.Add(Mode.Arabian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.h, Interval.W, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.AugmentedLydian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h });
            scaleIntervals.Add(Mode.Byzantine, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.h, Interval.W, Interval.h, Interval.Wh, Interval.h });
            scaleIntervals.Add(Mode.Egyptian, new Interval[] { Interval.R, Interval.W, Interval.Wh, Interval.W, Interval.Wh, Interval.W });
            scaleIntervals.Add(Mode.HungarianMajor, new Interval[] { Interval.R, Interval.Wh, Interval.h, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W });
            scaleIntervals.Add(Mode.NeopolitanMajor, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W, Interval.h });
            scaleIntervals.Add(Mode.BalinesePelog, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.WW, Interval.h, Interval.WW });
            scaleIntervals.Add(Mode.Prometheus, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.Wh, Interval.h, Interval.W });
            scaleIntervals.Add(Mode.SixToneSymmetrical, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.h, Interval.Wh, Interval.h, Interval.Wh });
            scaleIntervals.Add(Mode.Altered, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.Chinese, new Interval[] { Interval.R, Interval.WW, Interval.W, Interval.h, Interval.WW, Interval.h });
            scaleIntervals.Add(Mode.DiminishedLydian, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.Wh, Interval.h, Interval.W, Interval.W, Interval.h });
            scaleIntervals.Add(Mode.EightToneSpanish, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.h, Interval.h, Interval.W, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.Hindu, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.HungarianMinor, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.Wh, Interval.h, Interval.h, Interval.Wh, Interval.h });
            scaleIntervals.Add(Mode.Kumoi, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.WW, Interval.W, Interval.Wh });
            scaleIntervals.Add(Mode.Locrian2, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.Lydian9, new Interval[] { Interval.R, Interval.Wh, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h });
            scaleIntervals.Add(Mode.MinorLydian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.h, Interval.h, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.MixolydianB6, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.Persian, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.h, Interval.h, Interval.W, Interval.Wh, Interval.h });
            scaleIntervals.Add(Mode.PrometheusNeopolitan, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.W, Interval.Wh, Interval.h, Interval.W });
            scaleIntervals.Add(Mode.TodiTheta, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.Wh, Interval.h, Interval.h, Interval.Wh, Interval.h });
            scaleIntervals.Add(Mode.AlteredBb7, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W, Interval.h, Interval.Wh });
            scaleIntervals.Add(Mode.AugmentedIonian, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.Wh, Interval.h, Interval.W, Interval.h });
            scaleIntervals.Add(Mode.Enigmatic, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.W, Interval.W, Interval.W, Interval.h, Interval.h });
            scaleIntervals.Add(Mode.Hirajoshi, new Interval[] { Interval.R, Interval.W, Interval.h, Interval.WW, Interval.h, Interval.WW });
            scaleIntervals.Add(Mode.Ichikosucho, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.h, Interval.h, Interval.h, Interval.W, Interval.W, Interval.h });
            scaleIntervals.Add(Mode.LeadingWholeTone, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W, Interval.h, Interval.h });
            scaleIntervals.Add(Mode.LydianB7, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.h, Interval.Wh, Interval.h, Interval.W });
            scaleIntervals.Add(Mode.MajorPhrygian, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.h, Interval.W, Interval.h, Interval.W, Interval.W });
            scaleIntervals.Add(Mode.Neopolitan, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.W, Interval.h, Interval.Wh, Interval.h });
            scaleIntervals.Add(Mode.Overtone, new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W });
            scaleIntervals.Add(Mode.PurviTheta, new Interval[] { Interval.R, Interval.h, Interval.Wh, Interval.W, Interval.h, Interval.h, Interval.Wh, Interval.h });
            scaleIntervals.Add(Mode.DorianB2, new Interval[] { Interval.R, Interval.h, Interval.W, Interval.W, Interval.h, Interval.W, Interval.h, Interval.W });

            return scaleIntervals;
        }

        public static Dictionary<Mode, string[]> GetScaleDegrees()
        {
            var scaleDegrees = new Dictionary<Mode, string[]>();

            scaleDegrees.Add(Mode.Ionian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Aeolian, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Phrygian, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Lydian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Mixolydian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Locrian, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Dorian, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.HarmonicMinor, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.MelodicMinor, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Augmented, new string[] { Degree.First, Degree.FlatThird, Degree.Third, Degree.Fifth, Degree.SharpFifth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.MinorPentatonic, new string[] { Degree.First, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.MajorPentatonic, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fifth, Degree.Sixth, Degree.Eighth });
            scaleDegrees.Add(Mode.Blues, new string[] { Degree.First, Degree.FlatThird, Degree.Fourth, Degree.SharpFourth, Degree.Fifth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.WholeTone, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.SharpFifth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.DiminishedWholeHalf, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.Sixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.DiminishedHalfWhole, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.FlatFourth, Degree.FlatFifth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Arabian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.SharpFourth, Degree.SharpFifth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.AugmentedLydian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.SharpFifth, Degree.Sixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Byzantine, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Egyptian, new string[] { Degree.First, Degree.Second, Degree.Fourth, Degree.Fifth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.HungarianMajor, new string[] { Degree.First, Degree.SharpSecond, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.NeopolitanMajor, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.BalinesePelog, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fifth, Degree.FlatSixth, Degree.Eighth });
            scaleDegrees.Add(Mode.Prometheus, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.FlatFifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.SixToneSymmetrical, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.Fourth, Degree.SharpFifth, Degree.Sixth, Degree.Eighth });
            scaleDegrees.Add(Mode.Altered, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.FlatFourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Chinese, new string[] { Degree.First, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.DiminishedLydian, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.EightToneSpanish, new string[] { Degree.First, Degree.FlatSecond, Degree.SharpSecond, Degree.Third, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Hindu, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.HungarianMinor, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.SharpFourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Kumoi, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.Sixth, Degree.Eighth });
            scaleDegrees.Add(Mode.Locrian2, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Lydian9, new string[] { Degree.First, Degree.SharpSecond, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.MinorLydian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.MixolydianB6, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Persian, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.FlatFifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.PrometheusNeopolitan, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.FlatFifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.TodiTheta, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.SharpFourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.AlteredBb7, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.FlatFourth, Degree.FlatFifth, Degree.FlatSixth, Degree.FlatFlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.AugmentedIonian, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.SharpFifth, Degree.Sixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Enigmatic, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.SharpFourth, Degree.SharpFifth, Degree.SharpSixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Hirajoshi, new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.FlatSixth, Degree.Eighth });
            scaleDegrees.Add(Mode.Ichikosucho, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.Fourth, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.LeadingWholeTone, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.SharpFifth, Degree.SharpSixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.LydianB7, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.MajorPhrygian, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Neopolitan, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.Overtone, new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth });
            scaleDegrees.Add(Mode.PurviTheta, new string[] { Degree.First, Degree.FlatSecond, Degree.Third, Degree.SharpFourth, Degree.Fifth, Degree.FlatSixth, Degree.Seventh, Degree.Eighth });
            scaleDegrees.Add(Mode.DorianB2, new string[] { Degree.First, Degree.FlatSecond, Degree.FlatThird, Degree.Fourth, Degree.Fifth, Degree.Sixth, Degree.FlatSeventh, Degree.Eighth });

            return scaleDegrees;
        }

    }
}
