using Keyify.Web.Enums;
using Keyify.Web.Models.Tunings;
using KeyifyWebClient.Models.Instruments;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class MandolinController : InstrumentController
    {
        private readonly Tuning _tuning;
        private readonly int _fretCount = 20;
        private readonly string _instrumentName = "Mandolin";
        private readonly InstrumentType _instrumentType = InstrumentType.Mandolin;

        public MandolinController(InstrumentViewModel instrumentViewModel) : base(instrumentViewModel)
        {
            _tuning = new StandardMandolinTuning();

            Model.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}