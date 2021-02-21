using Keyify.Models;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;
using KeyifyClassLibrary.Core.Domain.Tuning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace KeyifyWebClient.Core.Models
{
    //Be careful renaming this class! (It may not rename the reference in the Views)
    public class InstrumentViewModel
    {
        protected IScaleListService _dictionaryService;
        protected IScaleService _scaleDirectoryService;

        public string InstrumentName { get; set; } = "Instrument Not Named";
        public List<FretboardNote> Notes { get; } = new List<FretboardNote>();

        public List<FretboardNote> SelectedNotes => Notes.Where(n => n.Selected).ToList();
        public string SelectedNotesJson => JsonSerializer.Serialize(SelectedNotes.Select(n => n.Note.ToString()));

        public List<FretboardNote> UnselectedNotes => Notes.Where(n => !n.Selected).ToList();
        public List<FretboardNote> NotesPartOfScale => Notes.Where(n => n.InSelectedScale).ToList();

        public Fretboard Fretboard { get; private set; }
        public ScaleListEntry SelectedScale { get; set; }
        public List<ScaleListEntry> Scales { get; set; } = new List<ScaleListEntry>();
        public List<ScaleListEntry> SelectedScales => Scales.Where(s => s.Selected).ToList();

        public InstrumentViewModel(IScaleListService dictionaryService, IScaleService scaleDirectoryService)
        {
            Notes = PopulateSelectedNotesList();
            _dictionaryService = dictionaryService;
            _scaleDirectoryService = scaleDirectoryService;
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

        public void ResetNotesInScale()
        {
            foreach (var selectedNote in NotesPartOfScale)
            {
                selectedNote.InSelectedScale = false;
            }
        }

        public void ResetSelectedScales()
        {
            foreach (var selectedScale in SelectedScales)
            {
                selectedScale.Selected = false;
            }
        }

        public void ApplySelectedNotesToFretboard()
        {
            if (SelectedNotes == null || !SelectedNotes.Any())
            {
                return;
            }

            //TODO: This should happen when you're building the fretboard, the strings are being constructed... and then reiterated over... the first step is wasteful

            foreach (InstrumentString guitarString in Fretboard.InstrumentStrings)
            {
                foreach (FretboardNote fretboardNote in guitarString.Notes)
                {
                    var currentNote = SelectedNotes.SingleOrDefault(s => s.Equals(fretboardNote));

                    if (currentNote != null)
                    {
                        fretboardNote.Selected = currentNote.Selected;
                    }

                    if (SelectedScale != null && SelectedScale.Scale.NoteSet.Contains(fretboardNote.Note))
                    {                        
                        fretboardNote.InSelectedScale = true;
                    }
                }
            }
        }

        private List<FretboardNote> PopulateSelectedNotesList()
        {
            var fretboardNotes = new List<FretboardNote>(EnumHelper.GetEnumNameCount(typeof(Note)));

            foreach (Note note in Enum.GetValues(typeof(Note)))
            {
                fretboardNotes.Add(new FretboardNote(note));
            }

            return fretboardNotes;
        }

        public void ProcessNotesAndScale(string selectedScale, IEnumerable<string> selectedNotes)
        {
            UpdateSelectedNotes(selectedNotes);

            if (SelectedNotes.Count > 1)
            {
                // TODO: Remove dependency on dictionaryService parameter... this is daft.
                Scales = ScaleDictionaryHelper.GetMatchedScales(SelectedNotes.Select(a => a.Note), _dictionaryService);
            }
            else
            {
                if (Scales != null && Scales.Any(a => a.Selected))
                {
                    Scales.SingleOrDefault(a => a.Selected).Selected = false;
                }

                Scales.Clear();

                ResetNotesInScale();

                SelectedScale = null;

                if (!selectedNotes.Any())
                {
                    ResetSelectedNotes();
                }
            }

            ApplySelectedScales(selectedScale);

            ApplySelectedNotesToFretboard();
        }

        public void UpdateSelectedNotes(IEnumerable<string> selectedNotes)
        {
            var noteStack = new Stack<string>(selectedNotes);

            ResetSelectedNotes();

            while (noteStack.Any())
            {
                var selectedNote = noteStack.Pop();

                UnselectedNotes.Where(n => n.Note.ToString() == selectedNote).Single().Selected = true;
            }
        }

        public void ApplySelectedScales(string selectedScale)
        {
            ResetSelectedScales();

            if (!string.IsNullOrWhiteSpace(selectedScale))
            {
                SelectedScale = Scales.SingleOrDefault(a => a.ScaleLabel == selectedScale);

                if (SelectedScale != null)
                {
                    SelectedScale.Selected = true;
                    return;
                }

                SelectedScale = null;
            }
            else
            {
                SelectedScale = null;
            }
        }
    }
}