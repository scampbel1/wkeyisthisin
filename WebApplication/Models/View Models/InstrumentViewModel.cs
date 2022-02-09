using Keyify.Models.Interfaces;
using Keyify.Models.Service;
using Keyify.Models.View_Models.Misc;
using Keyify.Service.Interface;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyClassLibrary.Models.Interfaces;
using KeyifyWebClient.Models.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace KeyifyWebClient.Models.ViewModels
{
    //Be careful renaming this class! (It may not rename the reference in the Views)
    public class InstrumentViewModel
    {
        public List<InstrumentNote> Notes { get; } = new List<InstrumentNote>();
        public string InstrumentName { get; set; } = "Instrument Not Named";

        public List<InstrumentNote> SelectedNotes => Notes.Where(n => n.Selected).ToList();
        public string SelectedNotesJson => JsonSerializer.Serialize(SelectedNotes.Select(n => n.Note.ToString()));

        public List<InstrumentNote> UnselectedNotes => Notes.Where(n => !n.Selected).ToList();
        public List<InstrumentNote> NotesPartOfScale => Notes.Where(n => n.InSelectedScale).ToList();

        public Fretboard Fretboard { get; private set; }
        public ScaleEntry SelectedScale { get; set; }
        public List<ScaleEntry> Scales { get; set; } = new List<ScaleEntry>();
        public List<ScaleEntry> SelectedScales => Scales.Where(s => s.Selected).ToList();
        public string AvailableScalesLabel => GetAvailableScaleLabel();

        private IScalesGroupingService _groupedScales { get; init; }
        private List<ScaleGroupingEntry> AvailableScaleGroups => _groupedScales.GetGroupedScales();

        public List<ScaleGroupingEntry> Odd_Index_AvailableScaleGroups => AvailableScaleGroups.Where((a, i) => i % 2 != 0).ToList();
        public List<ScaleGroupingEntry> Even_Index_AvailableScaleGroups => AvailableScaleGroups.Where((a, i) => i % 2 == 0).ToList();

        protected IScaleListService DictionaryService { get; init; }
        protected IModeDefinitionService ScaleDirectoryService { get; init; }

        public InstrumentViewModel(IScaleListService dictionaryService, IModeDefinitionService scaleDirectoryService, IScalesGroupingService scalesGroupingService)
        {
            Notes = PopulateSelectedNotesList();
            DictionaryService = dictionaryService;
            ScaleDirectoryService = scaleDirectoryService;
            _groupedScales = scalesGroupingService;
        }

        public void UpdateViewModel(string instrumentName, ITuning tuning, int fretCount)
        {
            //TODO: Stop creating a new fretboard everytime
            Fretboard = new Fretboard(tuning, fretCount);
            InstrumentName = instrumentName;
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
                foreach (InstrumentNote fretboardNote in guitarString.Notes)
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

        public void ProcessNotesAndScale(string selectedScale, IEnumerable<string> selectedNotes)
        {
            UpdateSelectedNotes(selectedNotes);

            if (SelectedNotes.Count > 1)
            {
                Scales = DictionaryService.FindScales(SelectedNotes.Select(a => a.Note)).ToList();
                _groupedScales.UpdateScaleGroupingModel(Scales);
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

        private List<InstrumentNote> PopulateSelectedNotesList()
        {
            var fretboardNotes = new List<InstrumentNote>(EnumHelper.GetEnumNameCount(typeof(Note)));

            foreach (Note note in Enum.GetValues(typeof(Note)))
            {
                fretboardNotes.Add(new InstrumentNote(note));
            }

            return fretboardNotes;
        }

        private void UpdateSelectedNotes(IEnumerable<string> selectedNotes)
        {
            var noteStack = new Stack<string>(selectedNotes);

            ResetSelectedNotes();

            while (noteStack.Any())
            {
                var selectedNote = noteStack.Pop();

                UnselectedNotes.Where(n => n.Note.ToString() == selectedNote).Single().Selected = true;
            }
        }

        private void ApplySelectedScales(string selectedScale)
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

        private void ResetSelectedNotes()
        {
            foreach (var selectedNote in SelectedNotes)
            {
                selectedNote.Selected = false;
            }
        }

        private void ResetNotesInScale()
        {
            foreach (var selectedNote in NotesPartOfScale)
            {
                selectedNote.InSelectedScale = false;
            }
        }

        private void ResetSelectedScales()
        {
            foreach (var selectedScale in SelectedScales)
            {
                selectedScale.Selected = false;
            }
        }

        private string GetAvailableScaleLabel()
        {
            var matchingScaleCount = AvailableScaleGroups.Count;

            switch (matchingScaleCount)
            {
                case 0:
                    return GetNoScalesFoundMessage();
                case 1:
                    return $"{matchingScaleCount} Matching Scale Found";
                default:
                    return $"{matchingScaleCount} Matching Scales Found";
            }
        }

        private string GetNoScalesFoundMessage()
        {
            var selectedNoteCount = SelectedNotes.Count;

            if (selectedNoteCount == 1)
                return $"Only {selectedNoteCount} Note Selected";

            if (selectedNoteCount > 1)
                return "No Matching Scales Found";
            else
                return "No Notes Selected";
        }
    }
}