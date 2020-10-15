using KeyifyClassLibrary.Core.Domain.Enums;

namespace KeyifyClassLibrary.Core.Domain.Helper
{
    public static class ScaleHelper
    {
        public static Scale GenerateScaleFromKey(Note key, Step[] scaleSteps)
        {
            Scale scale = new Scale(key);
            int noteNumber = (int)key;

            foreach (Step scaleStep in scaleSteps)
            {
                noteNumber += (int)scaleStep;

                /*
                 * move back to 0, number of notes will never be larger than 12
                 */

                if (noteNumber > 11)
                {
                    noteNumber -= 12;
                }

                scale.AddNote((Note)noteNumber);
            }

            return scale;
        }
    }
}