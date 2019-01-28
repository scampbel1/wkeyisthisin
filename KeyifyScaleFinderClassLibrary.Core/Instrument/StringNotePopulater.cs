using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Helper;

namespace KeyifyScaleFinderClassLibrary.Core.Instrument
{
    public static class StringNotePopulater
    {
        public static Note[] Populate(Note openNote, int guitarFretCount)
        {
            var orderedNoteArray = new Note[guitarFretCount];
            var stringNoteIndex = (int)openNote;
            var count = 0;

            while (count < guitarFretCount)
            {
                orderedNoteArray[count] = (Note)stringNoteIndex;
                stringNoteIndex++;
                count++;

                if (stringNoteIndex >= EnumValuesConverter.GetNotes().Count)
                {
                    stringNoteIndex = 0;
                }
            }

            return orderedNoteArray;
        }
    }
}