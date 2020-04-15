using System;
using System.Collections.Generic;
using System.Linq;
using KeyifyClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyClassLibrary.Core.MusicTheory.Helper
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