﻿using Microsoft.AspNetCore.Mvc;
using Keyify.Models;
using Keyify.Service;
using KeyifyWebClient.Core.Models;
using Keyify.Domain.Tuning.Ukulele;
using Keyify.FrontendBuisnessLogic;
using KeyifyClassLibrary.Core.Domain.Tuning;

namespace Keyify.Controllers
{
    public class UkuleleController : Controller
    {
        private readonly ITuning _tuning;
        private readonly int _fretCount = 13;
        private readonly string _instrumentName = "Ukulele";

        FretboardWebModel _model;

        private IScaleDictionaryService _dictionaryService;
        private IScaleDirectoryService _scaleDirectoryService;

        public UkuleleController(IScaleDictionaryService dictionary, IScaleDirectoryService scaleDirectoryService)
        {
            _dictionaryService = dictionary;
            _scaleDirectoryService = scaleDirectoryService;
            _tuning = new StandardUkuleleTuning();
            _model = new FretboardWebModel(_fretCount, _tuning, _instrumentName);
        }

        [HttpGet]
        public IActionResult Index()
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