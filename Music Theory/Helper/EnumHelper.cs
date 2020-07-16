using KeyifyClassLibrary.Core.MusicTheory.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyClassLibrary.Core.MusicTheory.Helper
{
    public static class EnumHelper
    {
        public static List<string> GetAllNoteNames()
        {
            return Enum.GetNames(typeof(Note)).ToList();
        }

        public static List<string> GetAllModeNames()
        {
            return Enum.GetNames(typeof(Mode)).ToList();
        }
    }
}