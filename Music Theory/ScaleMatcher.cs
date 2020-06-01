using System.Collections.Generic;
using System.Linq;
using Keyify.Models;
using KeyifyClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public static class ScaleMatcher
    {
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