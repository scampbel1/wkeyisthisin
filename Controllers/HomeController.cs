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
                model.ApplySelectedNotesToFretboard(notes);

                if (!string.IsNullOrEmpty(scale))
                {
                    model.SelectedScale = ScaleDictionary.GenerateEntryFromString(scale);
                    model.ApplySelectedScaleNotesToFretboard(model.SelectedScale.Scale.NotesSet);
                }

                model.Scales = ScaleMatcher.GetMatchedScales(ElementStringConverter.ConvertStringArrayIntoNotes(notes));                
                model.SelectedNotes = new List<string>(notes);
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