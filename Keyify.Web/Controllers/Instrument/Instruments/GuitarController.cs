using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Web.Models.Tunings;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Services.Interfaces;
using KeyifyWebClient.Models.Instruments;
using Microsoft.Extensions.Configuration;

namespace Keyify.Web.Controllers.Instrument.Instruments
{
    public class GuitarController : InstrumentController
    {
        private readonly Tuning _tuning;
        private readonly int _fretCount = 24;
        private readonly InstrumentType _instrumentType = InstrumentType.Guitar;

        public GuitarController(
            InstrumentViewModel instrumentViewModel,
            IConfiguration configuration,
            IMusicTheoryService musicTheoryService,
            IFretboardService fretboardService,
            IScaleGroupingHtmlService scaleGroupingHtmlService,
            IQuickLinkService quickLinkService,
            IChordDefinitionGroupingHtmlService chordDefintionsGroupingHtmlService)
            : base(
                instrumentViewModel,
                configuration,
                musicTheoryService,
                fretboardService,
                scaleGroupingHtmlService,
                quickLinkService,
                chordDefintionsGroupingHtmlService)
        {
            _tuning = new StandardGuitarTuning();

            instrumentViewModel.Fretboard.UpdateFretboard(_instrumentType, _tuning, _fretCount);

            Model.UpdateViewModel(instrumentViewModel.Fretboard);
        }
    }
}