using Keyify.Models;
using KeyifyClassLibrary.Core.MusicTheory;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;
using KeyifyWebClient.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Business_Logic
{
    public static class FretboardFunctions
    {
        public static void FindScales(FretboardWebModel model, string scale, string[] notes, IScaleDictionaryService dictionaryService)
        {
            List<Note> realNotes = ElementStringConverter.ConvertStringArrayIntoNotes(notes);
            model.Scales = ScaleMatcher.GetMatchedScales(realNotes, dictionaryService);
            model.SelectedNotes = new List<string>(notes);

            if (!string.IsNullOrEmpty(scale))
            {
                model.SelectedScale = ScaleDictionary.GenerateEntryFromString(scale);

                var selected = new ScaleMatch(model.SelectedScale.ScaleName, model.SelectedScale.Scale.Notes);
                selected.Selected = true;

                if (!model.Scales.Any(a => a.ScaleName == selected.ScaleName))
                    model.Scales.Add(selected);
                else
                {
                    var update = model.Scales.Single(a => a.ScaleName == selected.ScaleName);
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
