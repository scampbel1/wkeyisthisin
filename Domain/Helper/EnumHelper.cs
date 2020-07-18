using System;
using System.Linq;
using System.Collections.Generic;
using KeyifyClassLibrary.Core.Domain.Enums;

namespace KeyifyClassLibrary.Core.Domain.Helper
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