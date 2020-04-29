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

                //Do not simplify this until you have unit tests in place for it
                if (!string.IsNullOrEmpty(scale))
                {
                    model.SelectedScale = ScaleDictionary.GenerateEntryFromString(scale);                    
                    var scaleSet = new HashSet<Note>(model.SelectedScale.Scale.NotesSet);

                    var selectedNotes = ElementStringConverter.ConvertStringArrayIntoNotes(notes);
                    scaleSet.IntersectWith(selectedNotes);
                    //Include scaleSet and selectedNotes match boolean to be shown on page using "widget"
                    model.SelectedNoteSelectedScaleMatch = scaleSet;
                }

                model.Scales = ScaleMatcher.GetMatchedScales(ElementStringConverter.ConvertStringArrayIntoNotes(notes));
            }

            return PartialView("FretboardMain", model);
        }

        [HttpPost]
        public ActionResult ResetModel()
        {
            var model = new FretboardWebModel();

            return PartialView("FretboardMain", model);
        }
    }
}