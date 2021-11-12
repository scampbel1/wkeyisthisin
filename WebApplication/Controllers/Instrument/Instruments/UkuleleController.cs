using Keyify.Controllers.Instrument;
using KeyifyClassLibrary.Models.Interfaces;
using KeyifyWebClient.Models.Instruments;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class UkuleleController : InstrumentController
    {
        private readonly ITuning _tuning;
        private readonly int _fretCount = 13;
        private readonly string _instrumentName = "Ukulele";

        public UkuleleController(InstrumentViewModel instrumentViewModel) : base(instrumentViewModel)
        {
            _tuning = new StandardUkuleleTuning();

            _instrumentViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}