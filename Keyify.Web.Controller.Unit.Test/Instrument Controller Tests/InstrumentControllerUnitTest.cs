using Keyify.Models.Interfaces;
using Keyify.Models.Service;
using Keyify.Service.Interfaces;
using KeyifyClassLibrary.Models.MusicTheory;
using KeyifyClassLibrary.Service_Models;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class InstrumentControllerUnitTest
    {
        protected const string _quickLinkScaleKey = "QLscale";
        protected const string _quickLinkNotesKey = "QLnotes";

        protected InstrumentViewModel instrumentViewModel;
        protected Mock<IScaleService> m_MockScaleService;
        protected Mock<IChordTemplateService> m_MockChordTemplateService;
        protected Mock<IScalesGroupingService> m_MockScalesGroupingService;

        public InstrumentControllerUnitTest()
        {
            m_MockScaleService = new Mock<IScaleService>();
            m_MockScalesGroupingService = new Mock<IScalesGroupingService>();
            m_MockChordTemplateService = new Mock<IChordTemplateService>();
            instrumentViewModel = new InstrumentViewModel(m_MockScaleService.Object, m_MockScalesGroupingService.Object, m_MockChordTemplateService.Object);

            m_MockScaleService.Setup(m => m.FindScales(It.IsAny<IEnumerable<Note>>())).Returns(
                new[] {
                    new ScaleEntry(new GeneratedScale(
                        Note.C,
                        new ModeDefinition(
                            Mode.Kumoi,
                            new Interval[] { Interval.R, Interval.W, Interval.h, Interval.WW, Interval.W, Interval.Wh},
                            new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.Sixth, Degree.Eighth })))
                });
        }
    }
}