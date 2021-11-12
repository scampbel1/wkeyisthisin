using Keyify.Controllers.Instrument;
using Keyify.Service.Interface;
using KeyifyClassLibrary.Models.Interfaces;
using KeyifyWebClient.Models.Instruments;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class GuitarController : InstrumentController
    {
        private readonly ITuning _tuning;
        private readonly string _instrumentName = "Guitar";
        private readonly int _fretCount = 24;

        public GuitarController(IScaleListService dictionary, IModeDefinitionService scaleDirectoryService, InstrumentViewModel instrumentViewModel) : base(instrumentViewModel)
        {
            _tuning = new StandardGuitarTuning();

            _instrumentViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}