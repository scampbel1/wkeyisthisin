﻿using System.Collections.Generic;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;

namespace KeyifyWebClient.Core.Models
{
    public class InstrumentString
    {
        public List<FretboardNote> Notes { get; set; }

        public InstrumentString(Note openNote, int fretCount)
        {
            Notes = Populate(openNote, fretCount);
        }

        private static List<FretboardNote> Populate(Note openNote, int fretCount)
        {
            var stringNoteIndex = (int)openNote;
            var count = 0;

            List<FretboardNote> notes = new List<FretboardNote>(fretCount);

            while (count < fretCount)
            {
                notes.Add(new FretboardNote((Note)stringNoteIndex));
                stringNoteIndex++;
                count++;

                if (stringNoteIndex >= EnumHelper.GetAllNoteNames().Count)
                {
                    stringNoteIndex = 0;
                }
            }

            return notes;
        }
    }
}