using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;

namespace Keyify.Domain.Helper
{
    public static class PentatonicModeHelper
    {
        public static PentatonicMode? GetModeNameColloquialism(Mode mode)
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

        public static string GetModeNameColloquialismModeLabel(Mode mode)
        {
            return GetModeNameColloquialism(mode).ToString();
        }

        public static string GetScaleColloquialism(Mode mode, Scale scale)
        {
            var pentatonicModeEquivalent = GetModeNameColloquialismModeLabel(mode);

            return !string.IsNullOrWhiteSpace(pentatonicModeEquivalent) ? $"{scale.RootNote} {pentatonicModeEquivalent}" : pentatonicModeEquivalent;
        }        
    }
}