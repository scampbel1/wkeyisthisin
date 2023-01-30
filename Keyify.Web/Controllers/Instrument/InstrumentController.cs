﻿using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Keyify.Controllers.Instrument
{
    public class InstrumentController : Controller
    {
        protected InstrumentViewModel _instrumentViewModel;

        public InstrumentController(InstrumentViewModel instrumentViewModel)
        {
            _instrumentViewModel = instrumentViewModel;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _instrumentViewModel.ApplySelectedNotesToFretboard();

            return View(_instrumentViewModel);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(List<string> previouslySelectedNotes, string newlySelectedNote, string selectedScale)
        {
            if (!string.IsNullOrWhiteSpace(newlySelectedNote) || previouslySelectedNotes != null)
            {
                if (!string.IsNullOrWhiteSpace(newlySelectedNote))
                {
                    if (previouslySelectedNotes.Contains(newlySelectedNote))
                    {
                        previouslySelectedNotes.Remove(newlySelectedNote);
                    }
                    else
                    {
                        previouslySelectedNotes.Add(newlySelectedNote);
                    }
                }

                _instrumentViewModel.ProcessNotesAndScale(selectedScale, previouslySelectedNotes);
            }

            return PartialView("Fretboard", _instrumentViewModel);
        }
    }
}