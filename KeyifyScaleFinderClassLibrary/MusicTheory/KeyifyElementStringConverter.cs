using System;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;

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

        public static HeptatonicMode ConvertStringModeNameToModeType(string mode)
        {
            return (HeptatonicMode)Enum.Parse(typeof(HeptatonicMode), mode, true);
        }
    }
}