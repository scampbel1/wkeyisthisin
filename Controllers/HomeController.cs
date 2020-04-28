using System.Collections.Generic;
using KeyifyClassLibrary.Core.MusicTheory;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeyifyWebClient.Core.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new FretboardWebModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] notes, string scale)
        {
            FretboardWebModel model = new FretboardWebModel();

            if (notes != null && notes.Length > 0)
            {
                foreach (var note in notes)
                {
                    model.Notes.Remove(note);
                    model.Notes.Add(note, true);
                }

                if (!string.IsNullOrEmpty(scale))
                {
                    model.SelectedScale = ScaleDictionary.GenerateEntryFromString(scale);
                    //Incorrect!!
                    model.SelectedNoteSelectedScaleMatch = new HashSet<KeyifyClassLibrary.Core.MusicTheory.Enums.Note>(model.SelectedScale.Scale.Notes);
                    model.SelectedNoteSelectedScaleMatch.SymmetricExceptWith(ElementStringConverter.ConvertStringArrayIntoNotes(notes));
                }

                model.Scales = GenerateScales(notes);
            }

            return PartialView("FretboardMain", model);
        }

        [HttpPost]
        public ActionResult ResetModel()
        {
            var model = new FretboardWebModel();

            return PartialView("FretboardMain", model);
        }

        private List<ScaleMatch> GenerateScales(string[] notes)
        {
            return ScaleMatcher.GetMatchedScales(ElementStringConverter.ConvertStringArrayIntoNotes(notes));
        }
    }
}