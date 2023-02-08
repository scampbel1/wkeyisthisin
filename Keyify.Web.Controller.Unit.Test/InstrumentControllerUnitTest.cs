using Keyify.Controllers.Instrument;
using Keyify.Models.Interfaces;
using Keyify.Models.Service;
using Keyify.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Models.MusicTheory;
using KeyifyClassLibrary.Service_Models;
using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;

namespace Keyify.Web.Controller.Unit.Test
{
    public class InstrumentControllerUnitTest
    {
        private InstrumentViewModel instrumentViewModel;
        private Mock<IScaleService> m_MockScaleService;
        private Mock<IChordTemplateService> m_MockChordTemplateService;
        private Mock<IScalesGroupingService> m_MockScalesGroupingService;

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

        [Fact]
        public void InstrumentController_CallIndex_NoQuickLinkTempData_NotesShouldBeEmpty()
        {
            var instrumentController = new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            instrumentController.Index();

            Assert.Empty(instrumentViewModel.SelectedNotes);
            Assert.Null(instrumentViewModel.SelectedScale);
        }

        [Fact]
        public void InstrumentController_CallIndex_ScaleOnlyInQuickLinkTempData_ScaleShouldBeNull()
        {
            var qlScale = "CKumoi";

            var instrumentController = new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            instrumentController.TempData["QLscale"] = qlScale;

            instrumentController.Index();

            Assert.Empty(instrumentViewModel.SelectedNotes);
            Assert.Null(instrumentViewModel.SelectedScale);
        }

        [Fact]
        public void InstrumentController_CallIndex_NotesnlyInQuickLinkTempData_ScaleShouldBeNull_NotesShouldContainSelectedNotes()
        {
            var qlNotes = new List<Note> { Note.A, Note.C, Note.G };

            var instrumentController = new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            instrumentController.TempData["QLnotes"] = qlNotes;

            instrumentController.Index();

            Assert.Equal(3, instrumentViewModel.SelectedNotes.Count);
            Assert.Null(instrumentViewModel.SelectedScale);
        }

        [Fact]
        public void InstrumentController_CallIndex_QuickLinkTempData_ViewModelShouldContainQuickLinkValues()
        {
            var qlNotes = new List<Note> { Note.A, Note.C, Note.G };
            var qlScale = "CKumoi";

            var instrumentController = new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            instrumentController.TempData["QLnotes"] = qlNotes;
            instrumentController.TempData["QLscale"] = qlScale;

            instrumentController.Index();

            Assert.Equal(3, instrumentViewModel.SelectedNotes.Count);
            Assert.Equal(qlScale, instrumentViewModel.SelectedScale.ScaleLabel);
        }

        [Fact]
        public void InstrumentController_UpdateFretboardModel_NewNoteAddedToSelectedNotes()
        {
            var newNote = Note.B;
            var selectedScale = "CKumoi";
            var previouslySeletedNotes = new List<Note> { Note.A, Note.C, Note.G };
            var expectedSelectedNotes = new List<Note>(previouslySeletedNotes) { newNote };

            var instrumentController = new InstrumentController(instrumentViewModel);

            instrumentController.UpdateFretboardModel(previouslySeletedNotes.Select(p => p.ToString()).ToList(), newNote.ToString(), selectedScale);

            Assert.Equal(selectedScale, instrumentViewModel.SelectedScale.ScaleLabel);
            Assert.Equal(expectedSelectedNotes.OrderBy(e => e), instrumentViewModel.SelectedNotes.Select(s => s.Note).OrderBy(o => o));
        }
    }
}