using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;

namespace KeyifyWebClient.Models
{
    public class FretboardWebModel
    {
        public readonly List<Note[]> Strings;

        public FretboardWebModel(IEnumerable<Note[]> strings)
        {
            Strings = strings as List<Note[]>;
        }
    }
}