using System.Linq;
using System.Collections.Generic;
using Keyify.Models;
using KeyifyWebClient.Core.Models;
using KeyifyClassLibrary.Core.MusicTheory;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;

namespace Keyify.Business_Logic
{
    public static class FretboardFunctions
    {
        public static void FindScales(FretboardWebModel model, string scale, string[] notes, IScaleDictionaryService dictionaryService)
        {
            List<Note> realNotes = NoteHelper.ConvertNoteStringArrayIntoNotes(notes);
            
            model.Scales = ScaleMatchHelper.GetMatchedScales(realNotes, dictionaryService);
            model.SelectedNotes = new List<string>(notes);

            if (!string.IsNullOrEmpty(scale))
            {
                model.SelectedScale = ScaleDictionaryHelper.GenerateEntryFromString(scale);

                ScaleMatch selected = new ScaleMatch(model.SelectedScale.ScaleName, model.SelectedScale.Scale.Notes);
                selected.Selected = true;

                if (!model.Scales.Any(a => a.ScaleName == selected.ScaleName))
                    model.Scales.Add(selected);
                else
                {
                    ScaleMatch update = model.Scales.Single(a => a.ScaleName == selected.ScaleName);

                    model.Scales.Remove(update);
                    model.Scales.Add(selected);
                }
            }
            else
                model.SelectedScale = null;

            model.ApplySelectedNotesToFretboard(realNotes, model.SelectedScale?.Scale.NotesSet);

            model.Scales = model.Scales.OrderBy(a => a.ScaleName).ToList();
        }
    }
}
