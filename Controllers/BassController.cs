using KeyifyClassLibrary.Core.MusicTheory;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;
using KeyifyClassLibrary.Core.MusicTheory.Tuning.Guitar;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Controllers
{
    public class BassController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new FretboardWebModel(16, new CustomStandardGuitarTuning(new Note[] { Note.E, Note.A, Note.D, Note.G }));
            
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] notes, string scale)
        {
            var model = new FretboardWebModel(16, new CustomStandardGuitarTuning(new Note[] { Note.E, Note.A, Note.D, Note.G }));

            if (notes != null && notes.Length > 0)
            {
                List<Note> realNotes = ElementStringConverter.ConvertStringArrayIntoNotes(notes);

                model.ApplySelectedNotesToFretboard(notes);
                model.Scales = ScaleMatcher.GetMatchedScales(realNotes);
                model.SelectedNotes = new List<string>(notes);
            }

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

                model.ApplySelectedScaleNotesToFretboard(model.SelectedScale.Scale.NotesSet);
            }
            else
                model.SelectedScale = null;

            model.Scales = model.Scales.OrderBy(a => a.ScaleName).ToList();

            return PartialView("Fretboard", model);
        }
    }
}
