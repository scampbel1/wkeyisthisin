using Keyify.Models.Service;
using KeyifyClassLibrary.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Keyify.Unit.Test.ScaleDictionary.UnitTests
{
    public class DuplicateModeDefinitionUnitTest
    {
        private List<ModeDefinition> _scaleEntries = new ModeDefinitionService(new ModeService()).Modes;

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
