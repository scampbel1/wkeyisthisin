using KeyifyClassLibrary.Core.Domain.Enums;

namespace KeyifyClassLibrary.Core.Domain
{
    public static partial class ScaleModeDictionary
    {
        public class ScaleDirectoryEntry
        {
            public Mode Mode { get; set; }
            public Step[] ScaleSteps { get; set; }

            public ScaleDirectoryEntry(Mode mode, Step[] scaleSteps)
            {
                Mode = mode;
                ScaleSteps = scaleSteps;
            }
        }
    }
}