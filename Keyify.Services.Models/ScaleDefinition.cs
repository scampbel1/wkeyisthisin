using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Models
{
    public class ScaleDefinition
    {
        public readonly string Name;
        public readonly Interval[] Intervals;
        public readonly string[] Degrees;

        //Create scales of all notes by default. Some scales are limited to a subset of notes.
        public readonly Array AllowedRootNotes = Enum.GetValues(typeof(Note));

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

        public ScaleDefinition(string name, Interval[] scaleIntervals, string[] scaleDegrees, Array allowedRootNotes) : this(name, scaleIntervals, scaleDegrees)
        {
            AllowedRootNotes = allowedRootNotes;
        }
    }
}