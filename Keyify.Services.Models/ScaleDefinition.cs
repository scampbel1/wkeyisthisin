using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Models
{
    public class ScaleDefinition
    {
        public readonly string Name;
        public readonly Interval[] Intervals;
        public readonly string[] Degrees;

        public readonly Note[] AllowedRootNotes = (Note[])Enum.GetValues(typeof(Note));

        public ScaleDefinition(string name, Interval[] intervals, string[] degrees)
        {
            Name = name;
            Intervals = intervals;
            Degrees = degrees;

            if (Intervals.Length != Degrees.Length)
            {
                throw new ArgumentException($"{nameof(Intervals)} length was not equal to length of {nameof(Degrees)}");
            }

            if (Degrees.Distinct().Count() != Degrees.Length)
            {
                throw new ArgumentException($"{nameof(Degrees)} contains duplicate(s)");
            }
        }

        public ScaleDefinition(string name, Interval[] scaleIntervals, string[] scaleDegrees, Note[] allowedRootNotes) : this(name, scaleIntervals, scaleDegrees)
        {
            AllowedRootNotes = allowedRootNotes;
        }
    }
}