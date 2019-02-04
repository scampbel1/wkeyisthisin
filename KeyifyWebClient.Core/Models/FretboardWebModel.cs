using System;
using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.Core.Instrument;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Tuning.Guitar;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KeyifyWebClient.Core.Models
{
    public class FretboardWebModel
    {
        public readonly List<string[]> Tuning;
        public readonly int Fretcount;

        public List<SelectListItem> Notes;

        public FretboardWebModel()
        {
            Notes = new List<SelectListItem>();
            Tuning = Fretboard.PopulateFretboard(new StandardGuitarTuning());
            Fretcount = 24;
            PopulateNotes();
        }

        private void PopulateNotes()
        {
            foreach (var note in (Note[])Enum.GetValues(typeof(Note)))
            {
                Notes.Add(new SelectListItem { Selected = false, Text = note.ToString(), Value = note.ToString() });
            }
        }
    }

    public class SelectedNoteItem
    {
        public Note Note { get; set; }
        public bool Selected { get; set; }
    }
}