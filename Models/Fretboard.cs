using KeyifyClassLibrary.Core.MusicTheory.Tuning;
using System.Collections.Generic;

namespace KeyifyWebClient.Core.Models
{
    public class Fretboard
    {
        List<GuitarString> GuitarStrings { get; set; }

        public Fretboard(ITuning tuning, int fretCount)
        {
            GuitarStrings = new List<GuitarString>();
        }
    }
}