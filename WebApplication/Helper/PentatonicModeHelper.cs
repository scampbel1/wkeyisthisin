using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyClassLibrary.Models.MusicTheory;

namespace Keyify.Helper
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

        //TODO: Remove these static methods... they don't need to be here

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