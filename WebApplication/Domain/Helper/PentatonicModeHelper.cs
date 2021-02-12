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
    }
}
