﻿using Keyify.Models.Interfaces;
using Keyify.Web.Enums;
using Keyify.Web.Models.Tunings;
using Keyify.Web.Service.Interfaces;
using KeyifyWebClient.Models.Instruments;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class MandolinController : InstrumentController
    {
        private readonly Tuning _tuning;
        private readonly int _fretCount = 20;
        private readonly InstrumentType _instrumentType = InstrumentType.Mandolin;

        public MandolinController(InstrumentViewModel instrumentViewModel, IMusicTheoryService musicTheoryService, IGroupedScalesService scalesPresentationService, IFretboardService fretboardService) : base(instrumentViewModel, musicTheoryService, scalesPresentationService, fretboardService)
        {
            _tuning = new StandardMandolinTuning();

            instrumentViewModel.Fretboard.UpdateFretboard(_instrumentType, _tuning, _fretCount);

            Model.UpdateViewModel(instrumentViewModel.Fretboard);
        }
    }
}