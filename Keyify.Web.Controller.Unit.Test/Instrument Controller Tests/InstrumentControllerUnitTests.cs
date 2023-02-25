using Keyify.Controllers.Instrument;
using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Formatter.Services;
using Keyify.Web.Models.Instruments;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Service.Interfaces;
using Keyify.Web.Services;
using Keyify.Web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class InstrumentControllerUnitTests
    {
        protected const string _quickLinkScaleKey = "QLscale";
        protected const string _quickLinkNotesKey = "QLnotes";

        protected readonly IFretboardService FretboardService;

        protected readonly Mock<IMusicTheoryService> m_MockMusicTheoryService;
        protected readonly Mock<IGroupedScalesService> m_MockGroupedScalesService;
        protected readonly Mock<IScaleGroupingHtmlService> m_MockScaleGroupingHtmlService;
        protected readonly Mock<IQuickLinkService> m_MockQuickLinkService;
        protected readonly Mock<IChordDefinitionGroupingHtmlService> m_MockChordDefinitionsGroupingHtmlService;

        private readonly Dictionary<Note, string> _sharpNotesDictionary;

        protected InstrumentViewModel InstrumentViewModel;

        public InstrumentControllerUnitTests()
        {
            _sharpNotesDictionary = new NoteFormatService().SharpNoteDictionary;

            InstrumentViewModel = new InstrumentViewModel(new Fretboard(_sharpNotesDictionary));

            m_MockMusicTheoryService = new Mock<IMusicTheoryService>();
            m_MockGroupedScalesService = new Mock<IGroupedScalesService>();
            m_MockScaleGroupingHtmlService = new Mock<IScaleGroupingHtmlService>();
            m_MockChordDefinitionsGroupingHtmlService = new Mock<IChordDefinitionGroupingHtmlService>();
            m_MockQuickLinkService = new Mock<IQuickLinkService>();

            FretboardService = new FretboardService(m_MockMusicTheoryService.Object, m_MockGroupedScalesService.Object);
        }

        protected InstrumentController CreateNewInstrumentController(InstrumentViewModel instrumentViewModel)
        {
            return new InstrumentController(instrumentViewModel, m_MockMusicTheoryService.Object, FretboardService, m_MockScaleGroupingHtmlService.Object, m_MockQuickLinkService.Object, m_MockChordDefinitionsGroupingHtmlService.Object)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };
        }
    }
}