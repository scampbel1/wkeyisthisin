using KeyifyClassLibrary.Core.Domain.Enums;

namespace KeyifyClassLibrary.Core.Domain.Helper
{
    public static class ScaleHelper
    {
        /// <summary>
        /// Taking the starting note, and a sequence of steps, return the complete scale, one note at a time.
        /// If the note number increases to a value greater than 12, subtract 12 to "loop back round" to correct note.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="scaleSteps"></param>
        /// <returns></returns>
        public static Scale GenerateScaleFromKey(Note key, Step[] scaleSteps)
        {
            int noteNumber = (int)key;
            Scale scale = new Scale(key);

            foreach (Step scaleStep in scaleSteps)
            {
                noteNumber += (int)scaleStep;
                
                if (noteNumber > 11)
                    noteNumber -= 12;

                scale.AddNote((Note)noteNumber);
            }

            return scale;
        }
    }
}