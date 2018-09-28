using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public static class EnumValuesConverter
    {
        public static List<string> GetNotes()
        {
            return Enum.GetNames(typeof(Note)).ToList();
        }

        public static List<string> GetModes()
        {
            return Enum.GetNames(typeof(HeptatonicModes)).ToList();
        }
    }
}