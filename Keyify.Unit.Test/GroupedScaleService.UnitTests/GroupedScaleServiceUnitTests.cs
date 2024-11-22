using Keyify.Web.Service;
using Keyify.Web.Services.Interfaces;
using System;

namespace Keyify.Web.Unit.Test.GroupedScaleServiceTest.UnitTests
{
    public class GroupedScaleServiceUnitTests
    {
        private readonly Mock<IScaleGroupingHtmlService> _scaleGroupingHtmlService;

        protected readonly GroupedScalesService _groupedScalesService;

        public GroupedScaleServiceUnitTests()
        {
            _scaleGroupingHtmlService = new Mock<IScaleGroupingHtmlService>();
            _groupedScalesService = new GroupedScalesService(_scaleGroupingHtmlService.Object);
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
