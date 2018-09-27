using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using KeyifyScaleFinderClassLibrary.Theory;

namespace GuitarKeyFinder
{
    public delegate void GuitarComponentDebugWriter(string input);

    public static class StringNotePopulater
    {
        static void OnPopulateFretboard(string note)
        {
            Debug.WriteLine("string populated", note);
        }

        static void OnPopulateFretboardEcho(string note)
        {
            Debug.WriteLine("string populated... (echo)", note);
        }

        public static Note[] Populate(Note openNote, int guitarFretCount)
        {
            Note[] orderedNoteArray = new Note[guitarFretCount];
            int stringNoteIndex = (int)openNote;
            int count = 0;

            var output = new GuitarComponentDebugWriter(OnPopulateFretboard);
            var outputEcho = new GuitarComponentDebugWriter(OnPopulateFretboardEcho);


            while (count < guitarFretCount)
            {
                orderedNoteArray[count] = (Note)stringNoteIndex;
                stringNoteIndex++;
                count++;

                if (stringNoteIndex >= KeyifyGetEnumValues.GetNotes().Count) stringNoteIndex = 0;
            }

            output += outputEcho;
            output(openNote.ToString());

            return orderedNoteArray;
        }
    }

    public static class Fretboard
    {
        public static List<Note[]> PopulateFretboard(ITuning tuning, int fretCount = 24)
        {
            var fretboard = new List<Note[]>();

            foreach (Note note in tuning.ReturnNotes().Reverse())
            {
                fretboard.Add(StringNotePopulater.Populate(note, fretCount));
            }

            return fretboard;
        }
    }
}