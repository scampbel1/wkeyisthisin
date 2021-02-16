using KeyifyClassLibrary.Core.Domain.Enums;
using static KeyifyClassLibrary.Core.Domain.ScaleModeDictionary;

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
        /// <param name="scaleLabel"></param>
        /// <returns></returns>
        public static Scale GenerateScale(Note key, ScaleDirectoryEntry scaleDirectoryEntry)
        {
            int noteNumber = (int)key;
            
            Scale scale = new Scale(key, scaleDirectoryEntry.Mode);

            foreach (Step scaleStep in scaleDirectoryEntry.ScaleSteps)
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