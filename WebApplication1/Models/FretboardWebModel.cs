using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;

namespace KeyifyWebClient.Models
{
    public class FretboardWebModel
    {
        public readonly List<Note[]> Strings;
        public readonly int Fretcount;

        public FretboardWebModel(IEnumerable<Note[]> strings, int fretcount)
        {
            Strings = strings as List<Note[]>;
            Fretcount = fretcount;
        }
    }
}