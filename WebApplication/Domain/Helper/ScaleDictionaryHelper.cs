using Keyify.Models;
using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyifyClassLibrary.Core.Domain.Helper
{
    public static class ScaleDictionaryHelper
    {
        public static List<ScaleListEntry> GetMatchedScales(IEnumerable<Note> selectedNotes, IScaleListService listService)
        {
            var listReference = listService.GetScaleList();

            return listReference.Where(a => a.Scale.NoteSet.IsSupersetOf(selectedNotes)).ToList();
        }

        /// <summary>
        /// Inserts spaces found where a capital letter is found
        /// </summary>
        /// <param name="label"></param>
        /// <returns>Stringbuilder modified input as a string</returns>
        public static string GetUserFriendlyLabel(string label)
        {
            StringBuilder sb = new StringBuilder().Append(label);
            int count = 1;

            while (count < sb.Length - 1)
            {
                if (char.IsUpper(sb[count]) && sb[count - 1] != ' ')
                    sb.Insert(count, ' ');

                count++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Removes any spaces found after the inital space between the root note and the scale name.
        /// It wouldn't remove the space in between "B" and "Aeolian" in "B Aeolian."
        /// </summary>
        /// <param name="inputScaleLabel"></param>
        /// <returns>Stringbuilder modified input as a string</returns>
        public static string ConvertUserFriendlyLabelIntoLabel(string inputScaleLabel)
        {
            StringBuilder sb = new StringBuilder().Append(inputScaleLabel);

            for (int i = 4; i <= sb.Length - 1; i++)
            {
                if (sb[i] == ' ')
                    sb.Remove(i, 1);
            }

            return sb.ToString();
        }
    }
}