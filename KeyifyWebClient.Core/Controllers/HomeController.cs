using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Helper;
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
        public ActionResult UpdateFretboardModel([FromBody] string[] notes, string scale)
        {
            FretboardWebModel model = new FretboardWebModel();

            if (notes.Length > 0)
            {
                foreach (var note in notes)
                {
                    model.Notes.Remove(note);
                    model.Notes.Add(note, true);
                }

                //TODO: Remove direct reference and reference a hosted instance of the REST Service
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
            return ScaleMatcher.GetMatchedScales(KeyifyElementStringConverter.ConvertStringArrayIntoNotes(notes));
        }
    }
}