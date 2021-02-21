using KeyifyClassLibrary.Enums;
using System;

namespace Keyify.Helper
{
    public static class ModeHelper
    {
        public static Mode ConvertStringModeNameToModeType(string mode)
        {
            return (Mode)Enum.Parse(typeof(Mode), mode, true);
        }

        public static string ConvertModeToModeLabel(Mode mode)
        {
            return mode.ToString();
        }
    }
}