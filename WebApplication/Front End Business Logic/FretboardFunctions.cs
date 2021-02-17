﻿using Keyify.Models;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;
using KeyifyWebClient.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.FrontendBuisnessLogic
{
    public static class FretboardFunctions
    {
        public static void ProcessNotesAndScale(InstrumentViewModel model, string selectedScale, string[] selectedNotes, IScaleListService dictionaryService, IScaleDirectoryService scaleDirectoryService)
        {
            UpdateSelectedNotes(selectedNotes, model);

            if (model.SelectedNotes.Count > 1)
            {
                model.Scales = ScaleDictionaryHelper.GetMatchedScales(model.SelectedNotes.Select(a => a.Note), dictionaryService);
                ApplySelectedScales(selectedScale, model);
            }
            else
            {
                if (model.Scales != null && model.Scales.Any(a => a.Selected))
                {
                    model.Scales.SingleOrDefault(a => a.Selected).Selected = false;
                }

                model.SelectedScale = null;
                model.Scales.Clear();
                model.ResetNotesInScale();
                
                if (!selectedNotes.Any())
                {
                    model.ResetSelectedNotes();
                }
            }

            model.ApplySelectedNotesToFretboard(model.SelectedNotes.Select(a => a.Note).ToList(), model.SelectedScale?.Scale.NotesSet);
        }

        public static List<FretboardNote> PopulateFretboard(Note openNote, int fretCount)
        {
            int stringNoteIndex = (int)openNote;
            int count = 0;

            List<FretboardNote> notes = new List<FretboardNote>(fretCount);

            while (count < fretCount)
            {
                notes.Add(new FretboardNote((Note)stringNoteIndex));
                stringNoteIndex++;
                count++;

                if (stringNoteIndex >= EnumHelper.GetEnumNameCount(typeof(Note)))
                    stringNoteIndex = 0;
            }

            return notes;
        }

        private static void UpdateSelectedNotes(IEnumerable<string> selectedNotes, InstrumentViewModel model)
        {
            var noteStack = new Stack<string>(selectedNotes);

            model.ResetSelectedNotes();

            while (noteStack.Any())
            {
                var selectedNote = noteStack.Pop();

                model.UnselectedNotes.Where(n => n.Note.ToString() == selectedNote).Single().Selected = true;
            }
        }

        private static void ApplySelectedScales(string selectedScale, InstrumentViewModel model)
        {
            model.ResetSelectedScales();

            if (!string.IsNullOrWhiteSpace(selectedScale))
            {
                model.SelectedScale = model.Scales.Single(a => a.ScaleLabel == selectedScale);
                model.SelectedScale.Selected = true;
            }
            else
            {
                model.SelectedScale = null;
            }
        }
    }
}