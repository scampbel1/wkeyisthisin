using Keyify.Web.Service;
using Keyify.Web.Service.Interfaces;
using KeyifyWebClient.Models.Instruments;
using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class InstrumentControllerUnitTests
    {
        protected const string _quickLinkScaleKey = "QLscale";
        protected const string _quickLinkNotesKey = "QLnotes";

        protected IFretboardService FretboardService;

        protected Mock<IMusicTheoryService> m_MockMusicTheoryService;
        protected Mock<IGroupedScalesService> m_MockGroupedScalesService;
        protected Mock<IScaleGroupingHtmlService> m_MockScaleGroupingHtmlService;

        protected InstrumentViewModel InstrumentViewModel => new InstrumentViewModel(new Fretboard());

        public InstrumentControllerUnitTests()
        {
            m_MockMusicTheoryService = new Mock<IMusicTheoryService>();
            m_MockGroupedScalesService = new Mock<IGroupedScalesService>();
            m_MockScaleGroupingHtmlService = new Mock<IScaleGroupingHtmlService>();
            FretboardService = new FretboardService(m_MockMusicTheoryService.Object, m_MockGroupedScalesService.Object);
        }

        protected InstrumentController CreateNewInstrumentController(InstrumentViewModel instrumentViewModel)
        {
            return new InstrumentController(instrumentViewModel, m_MockMusicTheoryService.Object, FretboardService, m_MockScaleGroupingHtmlService.Object)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };
        }
    }
}