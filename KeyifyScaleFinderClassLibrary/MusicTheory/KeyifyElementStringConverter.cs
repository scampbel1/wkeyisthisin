using System;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public static class KeyifyElementStringConverter
    {
        public static Note ConvertStringNoteToNoteType(string note)
        {
            return (Note)Enum.Parse(typeof(Note), note, true);
        }

        public static Note ConvertStringNoteToNoteType(char note)
        {
            return (Note)Enum.Parse(typeof(Note), note.ToString(), true);
        }

        public static HeptatonicModes ConvertStringModeNameToModeType(string mode)
        {
            return (HeptatonicModes)Enum.Parse(typeof(HeptatonicModes), mode, true);
        }
    }
}