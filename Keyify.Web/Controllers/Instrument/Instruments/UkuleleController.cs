using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Web.Models.Tunings;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Services.Interfaces;
using KeyifyWebClient.Models.Instruments;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class UkuleleController : InstrumentController
    {
        private readonly Tuning _tuning;
        private readonly int _fretCount = 13;
        private readonly InstrumentType _instrumentType = InstrumentType.Ukulele;

        public UkuleleController(InstrumentViewModel instrumentViewModel, IMusicTheoryService musicTheoryService, IFretboardService fretboardService, IScaleGroupingHtmlService scaleGroupingHtmlService, IQuickLinkService quickLinkService, IChordDefinitionGroupingHtmlService chordDefinitionsGroupingHtmlService) : base(instrumentViewModel, musicTheoryService, fretboardService, scaleGroupingHtmlService, quickLinkService, chordDefinitionsGroupingHtmlService)
        {
            _tuning = new StandardUkuleleTuning();

            instrumentViewModel.Fretboard.UpdateFretboard(_instrumentType, _tuning, _fretCount);

            Model.UpdateViewModel(instrumentViewModel.Fretboard);
        }
    }
}