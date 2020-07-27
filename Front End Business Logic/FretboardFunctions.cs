using System.Linq;
using System.Collections.Generic;
using Keyify.Models;
using Keyify.Service;
using KeyifyWebClient.Core.Models;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;

namespace Keyify.FrontendBuisnessLogic
{
    public static class FretboardFunctions
    {
        public static void FindScales(FretboardWebModel model, string selectedScale, string[] notes, IScaleDictionaryService dictionaryService, IScaleDirectoryService scaleDirectoryService)
        {
            List<Note> realNotes = NoteHelper.ConvertNoteStringArrayIntoNotes(notes);
            model.SelectedNotes = new List<string>(notes);

            if (model.SelectedNotes.Count > 1)
                model.Scales = ScaleDictionaryHelper.GetMatchedScales(realNotes, dictionaryService);

            if (!string.IsNullOrEmpty(selectedScale))
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
                
                if(model.Scales.Any(a => a.Value.Selected))
                {
                    model.Scales.SingleOrDefault(a => a.Value.Selected).Value.Selected = false;
                }
            }

            model.ApplySelectedNotesToFretboard(realNotes, model.SelectedScale?.Scale.NotesSet);
        }

        public static List<FretboardNote> Populate(Note openNote, int fretCount)
        {
            int stringNoteIndex = (int)openNote;
            int count = 0;

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