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
        }
    }
}
