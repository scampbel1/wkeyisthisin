using Keyify.Music_Theory.Helper;
using KeyifyClassLibrary.Core.Domain.Enums;

namespace KeyifyClassLibrary.Core.Domain
{
    public static partial class ScaleModeDictionary
    {
        public class ScaleDirectoryEntry
        {
            public readonly Mode Mode;
            public readonly string Label;
            public readonly Step[] ScaleSteps;

            public ScaleDirectoryEntry(Mode mode, Step[] scaleSteps)
            {
                Mode = mode;
                ScaleSteps = scaleSteps;
                Label = ModeHelper.ConvertModeToModeLabel(mode);
            }
        }
    }
}