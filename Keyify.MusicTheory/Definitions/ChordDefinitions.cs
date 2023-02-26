using Keyify.MusicTheory.Enums;

namespace Keyify.MusicTheory.Definitions
{
    public static class ChordDefinitions
    {
        public static Dictionary<ChordType, Interval[]> GetChordIntervals()
        {
            var chordIntervals = new Dictionary<ChordType, Interval[]>();

            chordIntervals.Add(ChordType.Major, new Interval[] { Interval.R, Interval.WW, Interval.Wh });
            chordIntervals.Add(ChordType.Minor, new Interval[] { Interval.R, Interval.Wh, Interval.WW });
            chordIntervals.Add(ChordType.Diminished, new Interval[] { Interval.R, Interval.Wh, Interval.Wh });
            chordIntervals.Add(ChordType.MajorSeventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW });
            chordIntervals.Add(ChordType.MinorSeventh, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh });
            chordIntervals.Add(ChordType.DominantSeventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh });
            chordIntervals.Add(ChordType.SuspendedSecond, new Interval[] { Interval.R, Interval.W, Interval.WWh });
            chordIntervals.Add(ChordType.SuspendedFourth, new Interval[] { Interval.R, Interval.WWh, Interval.W });
            chordIntervals.Add(ChordType.Augmented, new Interval[] { Interval.R, Interval.WW, Interval.WW });
            chordIntervals.Add(ChordType.MajorNinth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh });
            chordIntervals.Add(ChordType.MinorNinth, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW });
            chordIntervals.Add(ChordType.DominantNinth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW });
            chordIntervals.Add(ChordType.MajorEleventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.Wh });
            chordIntervals.Add(ChordType.MinorEleventh, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh });
            chordIntervals.Add(ChordType.DominantEleventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW, Interval.Wh });
            chordIntervals.Add(ChordType.MajorThirteenth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW });
            chordIntervals.Add(ChordType.MinorThirteenth, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW });
            chordIntervals.Add(ChordType.DominantThirteenth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW });

            return chordIntervals;
        }
    }
}
