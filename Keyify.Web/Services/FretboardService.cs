﻿using Keyify.MusicTheory.Enums;
using Keyify.Web.Factories;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Service.Interfaces;
using Keyify.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Web.Services
{
    public class FretboardService : IFretboardService
    {
        private const int MinimumSelectedNotes = 2;
        private readonly IMusicTheoryService _musicTheoryService;
        private readonly IGroupedScalesService _groupedScalesService;

        public FretboardService(IMusicTheoryService musicTheoryService, IGroupedScalesService groupedScalesService)
        {
            _musicTheoryService = musicTheoryService;
            _groupedScalesService = groupedScalesService;
        }

        public void UpdateViewModel(
            InstrumentViewModel viewModel,
            IEnumerable<Note> selectedNotes,
            string selectedScale,
            InstrumentType instrumentType)
        {
            UpdateSelectedNotes(viewModel, selectedNotes);

            if (viewModel.SelectedNotes.Count > MinimumSelectedNotes)
            {
                viewModel.Scales = _musicTheoryService
                    .FindScales(selectedNotes)
                    .ToList();

                _groupedScalesService.UpdateScaleGroupingModel(viewModel.Scales, selectedNotes);

                viewModel.AvailableScaleGroups = _groupedScalesService.GroupedScales;
            }
            else
            {
                if (viewModel.Scales != null && viewModel.Scales.Any(a => a.Selected))
                {
                    viewModel.Scales.SingleOrDefault(a => a.Selected).Selected = false;
                }

                viewModel.Scales.Clear();

                ResetNotesInScale(viewModel);

                viewModel.SelectedScale = null;

                if (!selectedNotes.Any())
                {
                    var instrument = InstrumentFactory.CreateInstrument(instrumentType);

                    viewModel.ResetNotes();

                    viewModel.Fretboard.UpdateFretboard(
                        instrument.InstrumentType,
                        instrument.Tuning,
                        instrument.FretCount);
                }
            }

            ApplySelectedScales(viewModel, selectedScale);

            void UpdateSelectedNotes(InstrumentViewModel viewModel, IEnumerable<Note> selectedNotes)
            {
                var noteStack = new Stack<Note>(selectedNotes);

                viewModel.ResetNotes();

                while (noteStack.Any())
                {
                    var selectedNote = noteStack.Pop();

                    viewModel.UnselectedNotes.Where(n => n.Note == selectedNote).Single().Selected = true;
                }
            }
        }

        public void UpdateUnlockedFretboard(InstrumentViewModel instrumentViewModel)
        {
            if (instrumentViewModel.SelectedNotes == null || !instrumentViewModel.SelectedNotes.Any())
            {
                return;
            }

            /*TODO: See whether the efficiency of this can be improved upon. Can this be taken care of outside of the viewmodel, and we present the "state" of the fretboard as it exists. 
             * It seems wasteful to iterate through every note, each time there is a change in state based on user input.
             * We could easily update a matrix and simply display that matrix on the screen.
             * 
             * References/Pointers could be used for the scale notes! We won't be sharing this "layer" with chords, only to display selected notes, each state will have the same characteristic!
            */

            if (instrumentViewModel.Fretboard != null && instrumentViewModel.Fretboard.InstrumentStrings.Any())
            {
                foreach (var guitarString in instrumentViewModel.Fretboard.InstrumentStrings)
                {
                    foreach (var instrumentNote in guitarString.Notes)
                    {
                        var currentNote = instrumentViewModel.SelectedNotes.SingleOrDefault(s => s.Equals(instrumentNote));

                        if (currentNote != null)
                        {
                            instrumentNote.Selected = currentNote.Selected;
                        }

                        if (instrumentViewModel.SelectedScale != null && instrumentViewModel.SelectedScale.Scale.NoteSet.Contains(instrumentNote.Note))
                        {
                            instrumentNote.InSelectedScale = true;

                            if (instrumentNote.InSelectedScale)
                            {
                                var currentNoteIndex = instrumentViewModel.SelectedScale.Scale.Notes.IndexOf(instrumentNote.Note);
                                instrumentNote.DegreeInScale = instrumentViewModel.SelectedScale.Scale.ScaleDegrees[currentNoteIndex];
                            }
                        }
                    }
                }
            }
        }

        private void ApplySelectedScales(InstrumentViewModel viewModel, string selectedScale)
        {
            ResetSelectedScales(viewModel);

            if (!string.IsNullOrWhiteSpace(selectedScale))
            {
                viewModel.SelectedScale = viewModel.Scales.SingleOrDefault(a => a.ScaleLabel == selectedScale);

                if (viewModel.SelectedScale != null)
                {
                    viewModel.SelectedScale.Selected = true;
                    return;
                }

                viewModel.SelectedScale = null;
            }
            else
            {
                viewModel.SelectedScale = null;
            }
        }

        private void ResetNotesInScale(InstrumentViewModel viewModel)
        {
            foreach (var selectedNote in viewModel.NotesPartOfScale)
            {
                selectedNote.InSelectedScale = false;
            }
        }

        private void ResetSelectedScales(InstrumentViewModel viewModel)
        {
            foreach (var selectedScale in viewModel.Scales.Where(s => s.Selected))
            {
                selectedScale.Selected = false;
            }
        }
    }
}
