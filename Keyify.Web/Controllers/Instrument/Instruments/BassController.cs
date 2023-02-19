using Keyify.Domain.Tunings.Bass;
using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Web.Models.Tunings;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Service.Interfaces;
using Keyify.Web.Services.Interfaces;

namespace Keyify.Controllers.Instrument.Instruments
{
    public class BassController : InstrumentController
    {
        private readonly Tuning _tuning;
        private const int _fretCount = 21;
        private readonly InstrumentType _instrumentType = InstrumentType.Bass;

        public BassController(InstrumentViewModel instrumentViewModel, IMusicTheoryService musicTheoryService, IFretboardService fretboardService, IScaleGroupingHtmlService scaleGroupingHtmlService, IQuickLinkService quickLinkService, IChordDefinitionGroupingHtmlService chordDefintionsGroupingHtmlService) : base(instrumentViewModel, musicTheoryService, fretboardService, scaleGroupingHtmlService, quickLinkService, chordDefintionsGroupingHtmlService)
        {
            _tuning = new StandardBassTuning();

            instrumentViewModel.Fretboard.UpdateFretboard(_instrumentType, _tuning, _fretCount);

            Model.UpdateViewModel(instrumentViewModel.Fretboard);
        }
    }
}