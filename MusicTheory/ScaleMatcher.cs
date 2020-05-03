using System.Collections.Generic;
using KeyifyClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public static class ScaleMatcher
    {
        public static List<ScaleMatch> GetMatchedScales(IEnumerable<Note> selectedNotes)
        {
            var matches = new List<ScaleMatch>();

            foreach (var scaleEntry in ScaleDictionary.GenerateHeptatonicDictionary())
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