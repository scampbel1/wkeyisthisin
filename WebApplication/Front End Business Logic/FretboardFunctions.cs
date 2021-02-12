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
        public static void FindScales(InstrumentViewModel model, string selectedScale, string[] selectedNotes, IScaleDictionaryService dictionaryService, IScaleDirectoryService scaleDirectoryService)
        {
            List<Note> realNotes;

            if (selectedNotes.Length > 0)
            {
                model.SelectedNotes.Clear();
                model.SelectedNotes.AddRange(selectedNotes);
                realNotes = NoteHelper.ConvertNoteStringArrayIntoNotes(selectedNotes);

                if (selectedNotes.Length > 1)
                    model.Scales = ScaleDictionaryHelper.GetMatchedScales(realNotes, dictionaryService);
                else
                    selectedScale = null;
            }
            else
            {
                model.SelectedNotes.Clear();
                model.Scales.Clear();
                return;
            }

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

            model.ApplySelectedNotesToFretboard(realNotes, model.SelectedScale?.Scale.NotesSet);
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
    }
}