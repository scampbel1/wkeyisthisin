using System;
using System.Collections.Generic;
using System.Linq;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyScaleFinderClassLibrary.Core.MusicTheory.Helper
{
    public static class EnumValuesConverter
    {
        public static List<string> GetNotes()
        {
            return Enum.GetNames(typeof(Note)).ToList();
        }

        public static List<string> GetModes()
        {
            return Enum.GetNames(typeof(HeptatonicMode)).ToList();
        }
    }
}