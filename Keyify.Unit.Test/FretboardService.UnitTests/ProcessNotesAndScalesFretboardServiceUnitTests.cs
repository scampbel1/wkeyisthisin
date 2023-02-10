using Keyify.Models.Service;
using Keyify.Models.ViewModels.Misc;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Models.MusicTheory;
using KeyifyWebClient.Models.ViewModels;
using Moq;
using System.Collections.Generic;

namespace Keyify.Web.Unit.Test.FretboardServiceTest.UnitTests
{
    public class ProcessNotesAndScalesFretboardServiceUnitTests : FretboardServiceUnitTests
    {
        [Fact]
        public void ViewModelHasExistingScalesAndNotes_NewInputPassedToMethod_ScalesAndKeysReset()
        {
            var selectedScale = string.Empty;
            var selectedNotes = new[] { Note.A, Note.Bb, Note.Ab, Note.C, Note.Db, Note.D };
            var viewModel = new InstrumentViewModel(_fretboard);

            viewModel.AvailableKeyGroups = new List<ScaleGroupingEntry>() {
                new ScaleGroupingEntry(
                    new List<ScaleEntry>() {
                        new ScaleEntry(
                            new GeneratedScale(
                                Note.A,
                                new ModeDefinition(
                                    Mode.Aeolian,
                                    new[] { Interval.WW },
                                    new[] { "" })))},
                    selectedNotes)};

            viewModel.AvailableScaleGroups = new List<ScaleGroupingEntry>() {
                new ScaleGroupingEntry(
                    new List<ScaleEntry>() {
                        new ScaleEntry(
                            new GeneratedScale(
                                Note.A,
                                new ModeDefinition(
                                    Mode.Aeolian,
                                    new[] { Interval.WW },
                                    new[] { "" })))},
                    selectedNotes)};

            m_MockMusicTheoryService.Setup(s => s.FindScales(It.IsAny<IEnumerable<Note>>())).Returns(new List<ScaleEntry>());
            m_MockGroupedScalesService.Setup(s => s.UpdateScaleGroupingModel(It.IsAny<IEnumerable<ScaleEntry>>(), It.IsAny<IEnumerable<Note>>()));

            _service.ProcessNotesAndScale(viewModel, selectedNotes, selectedScale);

            Assert.Null(viewModel.AvailableKeyGroups);
            Assert.Null(viewModel.AvailableScaleGroups);
        }
    }
}
