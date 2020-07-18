﻿using Microsoft.AspNetCore.Mvc;
using Keyify.Models;
using Keyify.Service;
using Keyify.Domain.Tuning.Bass;
using KeyifyWebClient.Core.Models;
using Keyify.FrontendBuisnessLogic;
using KeyifyClassLibrary.Core.Domain.Tuning;

namespace Keyify.Controllers
{
    public class BassController : Controller
    {
        private readonly int _fretCount = 21;
        private readonly ITuning _tuning;
        private readonly string _instrument = "Bass";

        private IScaleDictionaryService _dictionaryService;
        private IScaleDirectoryService _scaleDirectoryService;

        public BassController(IScaleDictionaryService dictionary, IScaleDirectoryService scaleDirectoryService)
        {
            _dictionaryService = dictionary;
            _scaleDirectoryService = scaleDirectoryService;
            _tuning = new StandardBassTuning();
        }

        //public BassController(IScaleDictionaryService dictionary, IScaleDirectoryService scaleDirectoryService, ITuning tuning)
        //{
        //    _dictionaryService = dictionary;
        //    _scaleDirectoryService = scaleDirectoryService;
        //    _tuning = tuning;
        //}

        [HttpGet]
        public ActionResult Index()
        {
            FretboardWebModel model = new FretboardWebModel(_fretCount, _tuning);
            model.InstrumentName = _instrument;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel(string[] notes, string scale)
        {
            FretboardWebModel model = new FretboardWebModel(_fretCount, _tuning);
            model.InstrumentName = _instrument;

            if (notes == null || notes.Length < 1)
                return PartialView("Fretboard", model);

            FretboardFunctions.FindScales(model, scale, notes, _dictionaryService, _scaleDirectoryService);

            return PartialView("Fretboard", model);
        }
    }
}
