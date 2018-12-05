using System;
using System.Linq;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;

namespace KeyifyScaleFinderClassLibrary.MusicTheory.Helper
{
    public static class KeyifyElementStringConverter
    {
        public static Note ConvertCharNoteToNoteType(string note)
        {
            return (Note) Enum.Parse(typeof(Note), note, true);
        }

        public static Note ConvertCharNoteToNoteType(char note)
        {
            return (Note) Enum.Parse(typeof(Note), note.ToString(), true);
        }

        public static HeptatonicMode ConvertStringModeNameToModeType(string mode)
        {
            return (HeptatonicMode) Enum.Parse(typeof(HeptatonicMode), mode, true);
        }

        public static Note ConvertSharpNoteToFlat(string note)
        {
            if (note.Length != 2 && note[1] != '#')
                throw new InvalidOperationException("Note must be sharp");

            try
            {
                Note convertedNote = ConvertCharNoteToNoteType(note[0]);

                if ((int) convertedNote >= EnumValuesConverter.GetNotes().Count)
                {
                    convertedNote = (Note) 0;
                }
                else
                {
                    convertedNote = convertedNote + 1;
                }

                return convertedNote;
            }
            catch
            {
                throw new Exception("Conversion went wrong");
            }
        }

        public static string ConvertNoteToStringEquivalent(Note note, bool convertFlatNotes = false)
        {
            if (!IsNoteSharpOrFlat(note))
                return note.ToString();

            try
            {
                if (!convertFlatNotes) return note.ToString();

                if (note == Note.Ab)
                    return "G#";

                return note - 1 + "#";
            }
            catch
            {
                throw new Exception("Conversion went wrong");
            }
        }

        public static bool IsNoteSharpOrFlat(Note note)
        {
            switch (note)
            {
                case Note.Ab:
                    return true;
                case Note.Bb:
                    return true;
                case Note.Eb:
                    return true;
                case Note.Db:
                    return true;
                case Note.Gb:
                    return true;
                default:
                    return false;
            }
        }
    }
}