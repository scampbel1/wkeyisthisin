using Keyify.Models.Service;
using Keyify.Services.Models;
using Keyify.Web.Infrastructure.Caches;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Unit.Test.ScaleDictionary.UnitTests
{
    public class DuplicateModeDefinitionUnitTest
    {
        private List<ModeDefinition> _scaleEntries = new ModeService(new ModeDataCache()).Modes;

        [Fact]
        public void NoDuplicateModeDefinitionsByScaleDegrees()
        {
            var scaleDegrees = _scaleEntries.Select(s => string.Join(",", s.ScaleDegrees));
            var scaleDegreeDuplicates = scaleDegrees.GroupBy(g => g).Where(s => s.Count() > 1);

            Assert.False(scaleDegreeDuplicates.Any());
        }

        [Fact]
        public void NoDuplicateModeDefinitionsByScaleSteps()
        {
            var scaleSteps = _scaleEntries.Select(s => string.Join(",", s.ScaleSteps));
            var scaleStepDuplicates = scaleSteps.GroupBy(g => g).Where(s => s.Count() > 1);

            Assert.False(scaleStepDuplicates.Any());
        }
    }
}
