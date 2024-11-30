using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Models
{
    public class ScaleDefinition
    {
        public readonly string Name;
        public readonly Interval[] Intervals;
        public readonly string[] Degrees;
        public readonly string Description;
        public readonly int Popularity;

        public readonly Note[] AllowedRootNotes = (Note[])Enum.GetValues(typeof(Note));

        public ScaleDefinition(
            string name,
            Interval[] intervals,
            string[] degrees,
            string description,
            Note[]? allowedRootNotes,
            int popularity = 3)
        {
            if (intervals.Length != degrees.Length)
            {
                throw new ArgumentException($"{name}: {nameof(Intervals)} length was not equal to length of {nameof(Degrees)}");
            }

            if (degrees.Distinct().Count() != degrees.Length)
            {
                throw new ArgumentException($"{nameof(Degrees)} contains duplicate(s)");
            }

            Name = name;
            Intervals = intervals;
            Degrees = degrees;
            Description = description;

            if (allowedRootNotes != null)
            {
                AllowedRootNotes = allowedRootNotes;
            }

            Popularity = popularity;
        }
    }
}