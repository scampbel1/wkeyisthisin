using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;

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

        public static string GetScaleColloquialism(Scale scale, bool convertToSharp = false)
        {
            var pentatonicModeEquivalent = GetModeNameColloquialismModeLabel(scale.ModeDefinition.Mode);

            return !string.IsNullOrWhiteSpace(pentatonicModeEquivalent) ? $"{NoteHelper.ConvertNoteToStringEquivalent(scale.RootNote, convertToSharp)} {pentatonicModeEquivalent}" : pentatonicModeEquivalent;
        }
    }
}