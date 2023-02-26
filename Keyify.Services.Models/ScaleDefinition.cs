using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Models
{
    public class ScaleDefinition
    {
        public readonly Mode Mode;
        public readonly Interval[] ScaleSteps;
        public readonly string[] ScaleDegrees;

        //Create scales of all notes by default. Some scales are limited to a subset of notes.
        public readonly Array AllowedRootNotes = Enum.GetValues(typeof(Note));

        public ScaleDefinition(Mode mode, Interval[] scaleSteps, string[] scaleDegrees)
        {
            Mode = mode;
            ScaleSteps = scaleSteps;
            ScaleDegrees = scaleDegrees;

            if (ScaleSteps.Length != ScaleDegrees.Length)
            {
                throw new ArgumentException($"{nameof(ScaleSteps)} length was not equal to length of {nameof(ScaleDegrees)}");
            }

            if (ScaleDegrees.Distinct().Count() != ScaleDegrees.Length)
            {
                throw new ArgumentException($"{nameof(ScaleDegrees)} contains duplicate(s)");
            }
        }

        public ScaleDefinition(Mode mode, Interval[] scaleSteps, string[] scaleDegrees, Array allowedRootNotes) : this(mode, scaleSteps, scaleDegrees)
        {
            AllowedRootNotes = allowedRootNotes;
        }
    }
}