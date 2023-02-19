using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Web.Models.Tunings;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Service.Interfaces;
using Keyify.Web.Services.Interfaces;
using KeyifyWebClient.Models.Instruments;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class GuitarController : InstrumentController
    {
        private readonly Tuning _tuning;
        private readonly int _fretCount = 24;
        private readonly InstrumentType _instrumentType = InstrumentType.Guitar;

        public GuitarController(InstrumentViewModel instrumentViewModel, IMusicTheoryService musicTheoryService, IFretboardService fretboardService, IScaleGroupingHtmlService scaleGroupingHtmlService, IQuickLinkService quickLinkService, IChordDefinitionGroupingHtmlService chordDefinitionsGroupingHtmlService) : base(instrumentViewModel, musicTheoryService, fretboardService, scaleGroupingHtmlService, quickLinkService, chordDefinitionsGroupingHtmlService)
        {
            _tuning = new StandardGuitarTuning();

            instrumentViewModel.Fretboard.UpdateFretboard(_instrumentType, _tuning, _fretCount);

            Model.UpdateViewModel(instrumentViewModel.Fretboard);
        }
    }
}