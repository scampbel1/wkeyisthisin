﻿using System.Collections.Generic;
using System.Linq;
using KeyifyClassLibrary.Core.MusicTheory;
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
                model.Scales = ScaleMatcher.GetMatchedScales(ElementStringConverter.ConvertStringArrayIntoNotes(notes));
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