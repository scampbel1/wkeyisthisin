using System.Collections.Generic;
using KeyifyClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public static class ScaleMatcher
    {
        //TODO: This should be created as a service rather than created each time
        public static List<ScaleMatch> GetMatchedScales(IEnumerable<Note> selectedNotes)
        {
            var matches = new List<ScaleMatch>();
            
            foreach (ScaleDictionaryEntry scaleEntry in ScaleDictionary.GenerateDictionary())
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