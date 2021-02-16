﻿using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;
using KeyifyClassLibrary.Core.Domain.Tuning;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyWebClient.Core.Models
{
    //Be careful renaming this class! (It may not rename the reference in the Views)
    public class InstrumentViewModel
    {
        public string InstrumentName { get; set; } = "Instrument Not Named";
        public List<FretboardNote> Notes { get; set; } = new List<FretboardNote>();
        public List<FretboardNote> SelectedNotes => Notes.Where(n => n.Selected).ToList();
        public List<FretboardNote> UnselectedNotes => Notes.Where(n => !n.Selected).ToList();
        public Fretboard Fretboard { get; private set; }
        public ScaleDictionaryEntry SelectedScale { get; set; }
        public Dictionary<string, ScaleDictionaryEntry> Scales { get; set; } = new Dictionary<string, ScaleDictionaryEntry>();

        public InstrumentViewModel()
        {
            Notes = PopulateSelectedNotesList();
        }

        public void UpdateViewModel(string instrumentName, ITuning tuning, int fretCount)
        {
            //TODO: Stop creating a new fretboard everytime
            Fretboard = new Fretboard(tuning, fretCount);
            InstrumentName = instrumentName;
        }

        public void ResetSelectedNotes()
        {
            foreach (var selectedNote in SelectedNotes)
            {
                selectedNote.Selected = false;
            }
        }

        public void ApplySelectedNotesToFretboard(IEnumerable<Note> selectedNotes, HashSet<Note> scaleNotes)
        {
            foreach (InstrumentString guitarString in Fretboard.InstrumentStrings)
            {
                foreach (FretboardNote fretboardNote in guitarString.Notes)
                {
                    if (selectedNotes.Contains(fretboardNote.Note))
                        fretboardNote.Selected = true;

                    if (scaleNotes != null)
                    {
                        if (scaleNotes.Contains(fretboardNote.Note))
                            fretboardNote.InSelectedScale = true;
                    }
                }
            }
        }

        private List<FretboardNote> PopulateSelectedNotesList()
        {
            var fretboardNotes = new List<FretboardNote>(EnumHelper.GetEnumNameCount(typeof(Note)));

            foreach (Note note in Enum.GetValues(typeof(Note)))
                fretboardNotes.Add(new FretboardNote(note));

            return fretboardNotes;
        }
    }
}