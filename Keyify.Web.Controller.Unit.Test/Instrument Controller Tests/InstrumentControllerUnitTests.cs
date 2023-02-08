using Keyify.Models.Interfaces;
using Keyify.Service.Interfaces;
using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class InstrumentControllerUnitTests
    {
        protected const string _quickLinkScaleKey = "QLscale";
        protected const string _quickLinkNotesKey = "QLnotes";

        protected Mock<IScaleService> m_MockScaleService;
        protected Mock<IChordTemplateService> m_MockChordTemplateService;
        protected Mock<IScalesGroupingService> m_MockScalesGroupingService;

        protected InstrumentViewModel InstrumentViewModel => new InstrumentViewModel(m_MockScaleService.Object, m_MockScalesGroupingService.Object, m_MockChordTemplateService.Object);

        public InstrumentControllerUnitTests()
        {
            m_MockScaleService = new Mock<IScaleService>();
            m_MockScalesGroupingService = new Mock<IScalesGroupingService>();
            m_MockChordTemplateService = new Mock<IChordTemplateService>();
        }

        protected static InstrumentController CreateNewInstrumentController(InstrumentViewModel instrumentViewModel)
        {
            return new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };
        }
    }
}