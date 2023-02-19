using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using Keyify.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keyify.Web.Unit.Test.FretboardServiceTest.UnitTests
{
    public class ProcessNotesAndScalesFretboardServiceUnitTests : FretboardServiceUnitTests
    {
        [Fact]
        public async Task ViewModelHasExistingScalesAndNotes_NewInputPassedToMethod_ScalesAndKeysReset()
        {
            //var selectedScale = string.Empty;
            //var selectedNotes = new[] { Note.A, Note.Bb, Note.Ab, Note.C, Note.Db, Note.D };
            //var viewModel = new InstrumentViewModel(_fretboard);

            //new GeneratedScale(
            //                    Note.A,
            //                    new ModeDefinition(
            //                        Mode.Aeolian,
            //                        new[] { Interval.WW },
            //                        new[] { "" }))

            //viewModel.AvailableKeyGroups = new List<ScaleGroupingEntry>() {
            //    new ScaleGroupingEntry(
            //        new List<ScaleEntry>() {
            //            new ScaleEntry()},
            //        selectedNotes)};

            //new GeneratedScale(
            //                    Note.A,
            //                    new ModeDefinition(
            //                        Mode.Aeolian,
            //                        new[] { Interval.WW },
            //                        new[] { "" }))

            //viewModel.AvailableScaleGroups = new List<ScaleGroupingEntry>() {
            //    new ScaleGroupingEntry(
            //        new List<ScaleEntry>() {
            //            new ScaleEntry(
            //                )},
            //        selectedNotes)};

            //m_MockMusicTheoryService.Setup(s => s.FindScales(It.IsAny<IEnumerable<Note>>())).ReturnsAsync(new List<ScaleEntry>());
            //m_MockGroupedScalesService.Setup(s => s.UpdateScaleGroupingModel(It.IsAny<IEnumerable<ScaleEntry>>(), It.IsAny<IEnumerable<Note>>()));

            //await _service.UpdateViewModel(viewModel, selectedNotes, selectedScale);

            //Assert.Null(viewModel.AvailableKeyGroups);
            //Assert.Null(viewModel.AvailableScaleGroups);
        }
    }
}
