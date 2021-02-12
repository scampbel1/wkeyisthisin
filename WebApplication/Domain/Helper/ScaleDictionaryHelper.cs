﻿using Keyify.Models;
using Keyify.Music_Theory.Helper;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static KeyifyClassLibrary.Core.Domain.ScaleModeDictionary;

namespace KeyifyClassLibrary.Core.Domain.Helper
{
    public static class ScaleDictionaryHelper
    {
        public static Dictionary<string, ScaleDictionaryEntry> GetMatchedScales(IEnumerable<Note> selectedNotes, IScaleDictionaryService dictionary)
        {
            Dictionary<string, ScaleDictionaryEntry> dictionaryReference = dictionary.GetScaleDictionary();

            return dictionaryReference.Values.Where(a => a.Scale.NotesSet.IsSupersetOf(selectedNotes)).ToDictionary(a => a.ScaleLabel, b => b);
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