using Keyify.Enums;
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
        public readonly ChordType[] ChordTypes;

        //Create scales of all notes by default. Some scales are limited to a subset of notes.
        public readonly Array KeysFoundForMode = Enum.GetValues(typeof(Note));

        //TODO: This breaks the Single Responsibility Principle - create something else for generating the chords
        public ModeDefinition(Mode mode, Step[] scaleSteps, string[] scaleDegrees, Array modeKeys = null, ChordType[] chordTypes = null)
        {
            Mode = mode;
            ChordTypes = chordTypes;
            ScaleSteps = scaleSteps;
            ScaleDegrees = scaleDegrees;

            if (modeKeys != null)
            {
                KeysFoundForMode = modeKeys;
            }

            if (ScaleSteps.Length != ScaleDegrees.Length)
            {
                throw new ArgumentException($"{nameof(ScaleSteps)} length was not equal to length of {nameof(ScaleDegrees)}");
            }

            if (ScaleDegrees.Distinct().Count() != ScaleDegrees.Length)
            {
                throw new ArgumentException($"{nameof(ScaleDegrees)} contains duplicate(s)");
            }

            if (ChordTypes != null && ChordTypes.Length != scaleSteps.Length)
            {
                throw new ArgumentException($"{nameof(ChordTypes)} length was not equal to length of {nameof(ScaleSteps)}");
            }
        }
    }
}