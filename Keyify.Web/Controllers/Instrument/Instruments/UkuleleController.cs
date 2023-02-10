using Keyify.Web.Enums;
using Keyify.Web.Models.Tunings;
using Keyify.Web.Service.Interfaces;
using KeyifyWebClient.Models.Instruments;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class UkuleleController : InstrumentController
    {
        private readonly Tuning _tuning;
        private readonly int _fretCount = 13;
        private readonly InstrumentType _instrumentType = InstrumentType.Ukulele;

        public UkuleleController(InstrumentViewModel instrumentViewModel, IMusicTheoryService musicTheoryService, IFretboardService fretboardService, IScaleGroupingHtmlService scaleGroupingHtmlService, IQuickLinkService quickLinkService) : base(instrumentViewModel, musicTheoryService, fretboardService, scaleGroupingHtmlService, quickLinkService)
        {
            _tuning = new StandardUkuleleTuning();

            instrumentViewModel.Fretboard.UpdateFretboard(_instrumentType, _tuning, _fretCount);

            Model.UpdateViewModel(instrumentViewModel.Fretboard);
        }
    }
}