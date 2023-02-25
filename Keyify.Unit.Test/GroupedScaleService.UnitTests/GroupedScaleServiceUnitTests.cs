using Keyify.Service.Interfaces;
using Keyify.Web.Service;
using System;

namespace Keyify.Web.Unit.Test.GroupedScaleServiceTest.UnitTests
{
    public class GroupedScaleServiceUnitTests
    {
        private readonly Mock<IChordDefinitionGroupingHtmlService> _chordDefinitionGroupingHtmlService;

        protected readonly GroupedScalesService _groupedScalesService;

        public GroupedScaleServiceUnitTests()
        {
            _chordDefinitionGroupingHtmlService = new Mock<IChordDefinitionGroupingHtmlService>();
            _groupedScalesService = new GroupedScalesService(_chordDefinitionGroupingHtmlService.Object);
        }

        [Fact(Skip = "Not Implemented. Test that Scales and Keys are cleared first, this has tripped you up more than once!")]
        public void UpdateScaleGroupingModel_ResetsExistingScalesAndKeys()
        {
            throw new NotImplementedException();

            //_groupedScalesService.UpdateScaleGroupingModel(new[] { new ScaleEntry(new GeneratedScale(
            //            Note.C,
            //            new ModeDefinition(
            //                Mode.Kumoi,
            //                new Interval[] { Interval.R, Interval.W, Interval.h, Interval.WW, Interval.W, Interval.Wh },
            //                new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.Sixth, Degree.Eighth }))) }, new Note[] { });            
        }
    }
}
