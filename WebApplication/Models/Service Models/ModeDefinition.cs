using KeyifyClassLibrary.Enums;
using System;
using System.Linq;

namespace Keyify.Models.Service
{
    public class ModeDefinition
    {
        public readonly Mode Mode;
        public readonly Step[] ScaleSteps;
        public readonly string[] ScaleDegrees;

        //Create scales of all notes by default. Some scales are limited to a subset of notes.
        public readonly Array KeysFoundForMode = Enum.GetValues(typeof(Note));

        public ModeDefinition(Mode mode, Step[] scaleSteps, string[] scaleDegrees)
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

        public ModeDefinition(Mode mode, Step[] scaleSteps, string[] scaleDegrees, Array modeKeys) : this(mode, scaleSteps, scaleDegrees)
        {
            KeysFoundForMode = modeKeys;
        }
    }
}