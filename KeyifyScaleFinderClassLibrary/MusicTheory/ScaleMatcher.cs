using System.Collections.Generic;
using System.Linq;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public static class ScaleMatcher
    {
        public static List<ScaleMatch> GetMatchedScales(Note[] selectedNotes, int maximumMissing = 0)
        {
            var scales = ScaleDictionary.GenerateDictionary();
            var matches = new List<ScaleMatch>();

            foreach (Note note in selectedNotes)
            {
                foreach (var scale in scales)
                {
                    if (scale.Scale.Notes.Contains(note))
                    {
                        if (matches.Any(a => a.ScaleName == scale.ScaleName))
                        {
                            matches.Single(a => a.ScaleName == scale.ScaleName)
                                .Scale.Add(note);
                        }
                        else
                        {
                            matches.Add(new ScaleMatch(scale.ScaleName, note));
                        }
                    }
                }
            }

            matches.RemoveAll(a => a.Scale.Count < (selectedNotes.Count() - maximumMissing));

            return matches;
        }
    }
}