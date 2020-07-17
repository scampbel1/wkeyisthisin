using Keyify.Models;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyifyClassLibrary.Core.MusicTheory.Helper
{
    public static class ScaleMatchHelper
    {

        //TODO: This should be moved to the dictionary, we don't need to generate this code every time
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

        //TODO: This should be moved to the dictionary, we don't need to generate this code every time
        public static string ConvertUserFriendlyLabelIntoLabel(string inputScale)
        {
            StringBuilder sb = new StringBuilder().Append(inputScale);

            for (int i = 4; i <= sb.Length - 1; i++)
            {
                if (sb[i] == ' ')
                    sb.Remove(i, 1);
            }

            return sb.ToString();
        }

        public static List<ScaleMatch> GetMatchedScales(IEnumerable<Note> selectedNotes, IScaleDictionaryService dictionary)
        {
            List<ScaleMatch> matches = new List<ScaleMatch>();

            foreach (ScaleDictionaryEntry scaleEntry in dictionary.GetDictionary().Where(a => a.Scale.NotesSet.IsSupersetOf(selectedNotes)))
            {
                matches.Add(new ScaleMatch(scaleEntry.ScaleName, scaleEntry.Scale.Notes));
            }

            return matches;
        }
    }
}