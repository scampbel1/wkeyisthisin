using Keyify.MusicTheory.Enums;

namespace Keyify.MusicTheory.Definitions
{
    public static class ChordDefinitions
    {
        public static Dictionary<ChordType, Interval[]> GetChordIntervals()
        {
            var chordIntervals = new Dictionary<ChordType, Interval[]>
            {
                { ChordType.Major, new Interval[] { Interval.R, Interval.WW, Interval.Wh } },
                { ChordType.Minor, new Interval[] { Interval.R, Interval.Wh, Interval.WW } },
                { ChordType.Diminished, new Interval[] { Interval.R, Interval.Wh, Interval.Wh } },
                { ChordType.MajorSeventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW } },
                { ChordType.MinorSeventh, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh } },
                { ChordType.DominantSeventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh } },
                { ChordType.SuspendedSecond, new Interval[] { Interval.R, Interval.W, Interval.WWh } },
                { ChordType.SuspendedFourth, new Interval[] { Interval.R, Interval.WWh, Interval.W } },
                { ChordType.Augmented, new Interval[] { Interval.R, Interval.WW, Interval.WW } },
                { ChordType.MajorNinth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh } },
                { ChordType.MinorNinth, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW } },
                { ChordType.DominantNinth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW } },
                { ChordType.MajorEleventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.Wh } },
                { ChordType.MinorEleventh, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh } },
                { ChordType.DominantEleventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW, Interval.Wh } },
                { ChordType.MajorThirteenth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW } },
                { ChordType.MinorThirteenth, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW } },
                { ChordType.DominantThirteenth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW } }
            };

            return chordIntervals;
        }
    }
}
