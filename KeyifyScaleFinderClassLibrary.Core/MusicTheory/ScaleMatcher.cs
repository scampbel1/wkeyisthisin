using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyScaleFinderClassLibrary.Core.MusicTheory
{
    public static class ScaleMatcher
    {
        public static List<ScaleMatch> GetMatchedScales(IEnumerable<Note> selectedNotes)
        {
            var matches = new List<ScaleMatch>();

            foreach (var scaleEntry in ScaleDictionary.GenerateDictionary())
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