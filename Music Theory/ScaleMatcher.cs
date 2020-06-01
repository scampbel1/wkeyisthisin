using System.Collections.Generic;
using Keyify.Models;
using KeyifyClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public static class ScaleMatcher
    {
        public static List<ScaleMatch> GetMatchedScales(IEnumerable<Note> selectedNotes, IScaleDictionaryService dictionary)
        {
            var matches = new List<ScaleMatch>();
            
            foreach (ScaleDictionaryEntry scaleEntry in dictionary.GetDictionary())
            {
                if (scaleEntry.Scale.NotesSet.IsSupersetOf(selectedNotes))
                {
                    matches.Add(new ScaleMatch(scaleEntry.ScaleName, scaleEntry.Scale.Notes));
                }
            }

            return matches;
        }
    }
}