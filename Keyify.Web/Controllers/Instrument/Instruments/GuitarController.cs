using Keyify.Web.Enums;
using Keyify.Web.Models.Tunings;
using KeyifyWebClient.Models.Instruments;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class GuitarController : InstrumentController
    {
        private readonly Tuning _tuning;
        private readonly string _instrumentName = "Guitar";
        private readonly int _fretCount = 24;
        private readonly InstrumentType _instrumentType = InstrumentType.Guitar;

        public GuitarController(InstrumentViewModel instrumentViewModel) : base(instrumentViewModel)
        {
            _tuning = new StandardGuitarTuning();

            Model.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}