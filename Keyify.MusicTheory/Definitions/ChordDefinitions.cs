using Keyify.MusicTheory.Enums;

namespace Keyify.MusicTheory.Definitions
{
    public static class ChordDefinitions
    {
        public static Dictionary<ChordType, Interval[]> GenerateChordDefinitions()
        {
            var chordDefinitions = new Dictionary<ChordType, Interval[]>();

            chordDefinitions.Add(ChordType.Major, new Interval[] { Interval.R, Interval.WW, Interval.Wh });
            chordDefinitions.Add(ChordType.Minor, new Interval[] { Interval.R, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.Diminished, new Interval[] { Interval.R, Interval.Wh, Interval.Wh });
            chordDefinitions.Add(ChordType.MajorSeventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.MinorSeventh, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh });
            chordDefinitions.Add(ChordType.DominantSeventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh });
            chordDefinitions.Add(ChordType.SuspendedSecond, new Interval[] { Interval.R, Interval.W, Interval.WWh });
            chordDefinitions.Add(ChordType.SuspendedFourth, new Interval[] { Interval.R, Interval.WWh, Interval.W });
            chordDefinitions.Add(ChordType.Augmented, new Interval[] { Interval.R, Interval.WW, Interval.WW });
            chordDefinitions.Add(ChordType.MajorNinth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh });
            chordDefinitions.Add(ChordType.MinorNinth, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.DominantNinth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.MajorEleventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.Wh });
            chordDefinitions.Add(ChordType.MinorEleventh, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh });
            chordDefinitions.Add(ChordType.DominantEleventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW, Interval.Wh });
            chordDefinitions.Add(ChordType.MajorThirteenth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.MinorThirteenth, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.DominantThirteenth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW });

            return chordDefinitions;
        }
    }
}
