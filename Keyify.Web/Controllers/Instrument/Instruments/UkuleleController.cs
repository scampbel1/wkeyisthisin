using Keyify.Web.Enums;
using Keyify.Web.Models.Tunings;
using KeyifyWebClient.Models.Instruments;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class UkuleleController : InstrumentController
    {
        private readonly Tuning _tuning;
        private readonly int _fretCount = 13;
        private readonly string _instrumentName = "Ukulele";
        private readonly InstrumentType _instrumentType = InstrumentType.Ukulele;

        public UkuleleController(InstrumentViewModel instrumentViewModel) : base(instrumentViewModel)
        {
            _tuning = new StandardUkuleleTuning();

            ViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}