using Keyify.Domain.Tunings.Bass;
using Keyify.Web.Enums;
using Keyify.Web.Models.Tunings;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class BassController : InstrumentController
    {
        private readonly Tuning _tuning;
        private const int _fretCount = 21;
        private const string _instrumentName = "Bass";
        private readonly InstrumentType _instrumentType = InstrumentType.Bass;

        public BassController(InstrumentViewModel instrumentViewModel) : base(instrumentViewModel)
        {
            _tuning = new StandardBassTuning();

            _instrumentViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}