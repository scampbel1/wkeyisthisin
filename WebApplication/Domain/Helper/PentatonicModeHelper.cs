using KeyifyClassLibrary.Core.Domain.Enums;
using System;

namespace Keyify.Domain.Helper
{
    public static class PentatonicModeHelper
    {
        public static Nullable<PentatonicMode> GetModeNameColloquialism(Mode mode)
        {
            switch (mode)
            {
                case Mode.Ionian:
                    return PentatonicMode.Major;
                case Mode.Aeolian:
                    return PentatonicMode.Minor;
                default:
                    return null;
            }
        }

        public static string GetModeNameColloquialismLabel(Mode mode)
        {
            return GetModeNameColloquialism(mode).ToString();
        }

        public static Nullable<Mode> GetModeFromPentatonicMode(PentatonicMode pentatonicMode)
        {
            switch (pentatonicMode)
            {
                case PentatonicMode.Major:
                    return Mode.Ionian;
                case PentatonicMode.Minor:
                    return Mode.Aeolian;
                default:
                    return null;
            }
        }

        public static string GetModeStringFromPentatonicMode(PentatonicMode pentatonicMode)
        {
            return GetModeFromPentatonicMode(pentatonicMode).ToString();
        }

        //public static string GetModeStringFromPentatonicMode(string pentatonicMode)
        //{
        //    if (EnumHelper.GetAllEnumNames(typeof(PentatonicMode)).Contains(pentatonicMode))
        //        return GetModeFromPentatonicMode((PentatonicMode)Enum.Parse(typeof(PentatonicMode), pentatonicMode)).ToString();
        //    else
        //        return string.Empty;
        //}
    }
}
