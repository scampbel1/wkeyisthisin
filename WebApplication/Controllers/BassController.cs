﻿using Keyify.Domain.Tuning.Bass;
using Keyify.FrontendBuisnessLogic;
using Keyify.Models;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain.Tuning;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keyify.Controllers
{
    public class BassController : Controller
    {
        private readonly int _fretCount = 21;
        private readonly ITuning _tuning;
        private readonly string _instrumentName = "Bass";

        InstrumentViewModel _model;

        private IScaleDictionaryService _dictionaryService;
        private IScaleDirectoryService _scaleDirectoryService;

        public BassController(IScaleDictionaryService dictionary, IScaleDirectoryService scaleDirectoryService, InstrumentViewModel instrumentViewModel)
        {
            _dictionaryService = dictionary;
            _scaleDirectoryService = scaleDirectoryService;

            _tuning = new StandardBassTuning();

            _model = instrumentViewModel;
            _model.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] selectedNotes, string selectedScale)
        {
            if (selectedNotes == null || selectedNotes.Length < 1)
                return PartialView("Fretboard", _model);

            FretboardFunctions.FindScales(_model, selectedScale, selectedNotes, _dictionaryService, _scaleDirectoryService);

            return PartialView("Fretboard", _model);
        }
    }
}
