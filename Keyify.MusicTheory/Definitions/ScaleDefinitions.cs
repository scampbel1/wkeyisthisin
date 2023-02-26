using Keyify.MusicTheory.Enums;

namespace Keyify.MusicTheory.Definitions
{
    public static class ScaleDefinitions
    {
        //TODO: Move everything from ScaleDefinitionCache to here (you'll need to use primitives to here, because using ScaleDefinition will cause circular reference)

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
    }
}
