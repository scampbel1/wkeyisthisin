using KeyifyClassLibrary.Core.Domain.Enums;

namespace KeyifyClassLibrary.Core.Domain
{
    public partial class ModeDictionary
    {
        public class ModeDefinition
        {
            public readonly Mode Mode;            
            public readonly Step[] ScaleSteps;

            public ModeDefinition(Mode mode, Step[] scaleSteps)
            {
                Mode = mode;
                ScaleSteps = scaleSteps;                
            }
        }
    }
}