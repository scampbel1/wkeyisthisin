using Keyify.Domain.Tunings.Bass;
using Keyify.Models.Interfaces;
using Keyify.Web.Enums;
using Keyify.Web.Models.Tunings;
using Keyify.Web.Service.Interfaces;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class BassController : InstrumentController
    {
        private readonly Tuning _tuning;
        private const int _fretCount = 21;
        private readonly InstrumentType _instrumentType = InstrumentType.Bass;

        public BassController(InstrumentViewModel instrumentViewModel, IMusicTheoryService musicTheoryService, IGroupedScalesService scalesPresentationService, IFretboardService fretboardService) : base(instrumentViewModel, musicTheoryService, scalesPresentationService, fretboardService)
        {
            _tuning = new StandardBassTuning();

            instrumentViewModel.Fretboard.UpdateFretboard(_instrumentType, _tuning, _fretCount);

            Model.UpdateViewModel(instrumentViewModel.Fretboard);
        }
    }
}