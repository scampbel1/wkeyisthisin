using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public static class ScaleMatcher
    {
        public static List<Tuple<string, List<Note>>> GetMatchedScales(Note[] selectedNotes, int maximumMissing = 0)
        {
            var Scales = ScaleDictionary.GenerateDictionary();
            var matches = new List<Tuple<string, List<Note>>>();

            foreach (Note note in selectedNotes)
            {
                foreach (var scale in Scales)
                {
                    if (scale.Item2.Notes.Contains(note))
                    {
                        if (matches.Any(a => a.Item1 == scale.Item1))
                        {
                            matches.Single(a => a.Item1 == scale.Item1)
                                .Item2.Add(note);
                        }
                        else
                        {
                            matches.Add(new Tuple<string, List<Note>>(scale.Item1, new List<Note>() { note }));
                        }
                    }
                }
            }

            matches.RemoveAll(a => a.Item2.Count < (selectedNotes.Count() - maximumMissing));

            return matches;
        }
    }
}