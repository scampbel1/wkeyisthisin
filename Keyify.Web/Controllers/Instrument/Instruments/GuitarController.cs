using Keyify.Service.Interfaces;
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

        public GuitarController(IScaleService dictionary, IModeService scaleDirectoryService, InstrumentViewModel instrumentViewModel) : base(instrumentViewModel)
        {
            _tuning = new StandardGuitarTuning();

            _instrumentViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}