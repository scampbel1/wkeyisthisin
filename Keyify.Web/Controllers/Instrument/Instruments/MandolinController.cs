using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Web.Controllers.Instrument;
using Keyify.Web.Models.Tunings;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Services.Interfaces;
using KeyifyWebClient.Models.Instruments;
using Microsoft.Extensions.Configuration;

namespace Keyify.Web.Controllers.Instrument.Instruments
{
    public class MandolinController : InstrumentController
    {
        private readonly Tuning _tuning;
        private readonly int _fretCount = 20;
        private readonly InstrumentType _instrumentType = InstrumentType.Mandolin;

        public MandolinController(InstrumentViewModel instrumentViewModel,
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
            _tuning = new StandardMandolinTuning();

            instrumentViewModel.Fretboard.UpdateFretboard(_instrumentType, _tuning, _fretCount);

            Model.UpdateViewModel(instrumentViewModel.Fretboard);
        }
    }
}