using KeyifyClassLibrary.Enums;

namespace KeyifyClassLibrary.Helper
{
    //TODO: Move everything from this class - helper classes are anti-patterns
    public static class NoteHelper
    {
        public static bool IsSharpOrFlat(Note note)
        {
            switch (note)
            {
                case Note.Ab:
                case Note.Bb:
                case Note.Eb:
                case Note.Db:
                case Note.Gb:
                    return true;
                default:
                    return false;
            }
        }

        public static string ConvertNoteToStringEquivalent(Note note, bool convertFlatNoteToSharp = false)
        {
            if (!convertFlatNoteToSharp || !IsSharpOrFlat(note))
                return note.ToString();

            if (note == Note.Ab)
                return "G#";

            return note - 1 + "#";
        }
    }
}