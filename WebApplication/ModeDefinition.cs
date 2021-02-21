using KeyifyClassLibrary.Core.Domain.Enums;
using System;

namespace Keyify
{
    public class ModeDefinition
    {
        public readonly Mode Mode;
        public readonly Step[] ScaleSteps;

        public readonly Array KeysFoundForMode;

        public ModeDefinition(Mode mode, Step[] scaleSteps)
        {
            Mode = mode;
            ScaleSteps = scaleSteps;
            KeysFoundForMode = Enum.GetValues(typeof(Note));
        }

        public ModeDefinition(Mode mode, Step[] scaleSteps, Array modeKeys)
        {
            Mode = mode;
            ScaleSteps = scaleSteps;
            KeysFoundForMode = modeKeys;
        }
    }
}