using Keyify.Models;
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
        public static void FindScales(InstrumentViewModel model,
                                      string selectedScale,
                                      string[] selectedNotes,
                                      IScaleDictionaryService dictionaryService,
                                      IScaleDirectoryService scaleDirectoryService)
        {
            UpdateSelectedNotes(selectedNotes, model);

            if (model.SelectedNotes.Count > 1)
                model.Scales = ScaleDictionaryHelper.GetMatchedScales(model.SelectedNotes.Select(a => a.Note), dictionaryService);
            else
                selectedScale = null;

            if (!string.IsNullOrWhiteSpace(selectedScale))
            {
                model.SelectedScale = dictionaryService.GetScale(selectedScale);
                model.SelectedScale.Selected = true;

                if (!model.Scales.Any(a => a.Value.ScaleLabel == model.SelectedScale.ScaleLabel))
                    model.Scales.Add(model.SelectedScale.ScaleLabel, model.SelectedScale);
                else
                {
                    model.Scales.Remove(model.SelectedScale.ScaleLabel);
                    model.Scales.Add(model.SelectedScale.ScaleLabel, model.SelectedScale);
                }
            }
            else
            {
                model.SelectedScale = null;

                if (model.Scales.Any(a => a.Value.Selected))
                    model.Scales.SingleOrDefault(a => a.Value.Selected).Value.Selected = false;
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
    }
}