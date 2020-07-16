using Keyify.Models;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyClassLibrary.Core.MusicTheory.Helper
{
    public static class ScaleMatchHelper
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