using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Models
{
    public class ScaleDefinition
    {
        public readonly Mode Mode;
        public readonly Interval[] ScaleIntervals;
        public readonly string[] ScaleDegrees;

        //Create scales of all notes by default. Some scales are limited to a subset of notes.
        public readonly Array AllowedRootNotes = Enum.GetValues(typeof(Note));

        public ScaleDefinition(Mode mode, Interval[] scaleIntervals, string[] scaleDegrees)
        {
            Mode = mode;
            ScaleIntervals = scaleIntervals;
            ScaleDegrees = scaleDegrees;

            if (ScaleIntervals.Length != ScaleDegrees.Length)
            {
                throw new ArgumentException($"{nameof(ScaleIntervals)} length was not equal to length of {nameof(ScaleDegrees)}");
            }

            if (ScaleDegrees.Distinct().Count() != ScaleDegrees.Length)
            {
                throw new ArgumentException($"{nameof(ScaleDegrees)} contains duplicate(s)");
            }
        }

        public ScaleDefinition(Mode mode, Interval[] scaleIntervals, string[] scaleDegrees, Array allowedRootNotes) : this(mode, scaleIntervals, scaleDegrees)
        {
            AllowedRootNotes = allowedRootNotes;
        }
    }
}