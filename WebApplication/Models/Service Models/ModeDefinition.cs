using KeyifyClassLibrary.Enums;
using System;

namespace Keyify.Models.Service
{
    public class ModeDefinition
    {
        public readonly Mode Mode;
        public readonly Step[] ScaleSteps;

        //Some scales are limited in the root note)
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