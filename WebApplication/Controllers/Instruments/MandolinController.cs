﻿using KeyifyClassLibrary.Models.Interfaces;
using KeyifyWebClient.Models.Instruments;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Controllers
{
    public class MandolinController : InstrumentController
    {
        private readonly ITuning _tuning;
        private readonly int _fretCount = 20;
        private readonly string _instrumentName = "Mandolin";

        public MandolinController(InstrumentViewModel instrumentViewModel) : base(instrumentViewModel)
        {
            _tuning = new StandardMandolinTuning();

            _instrumentViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}