using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Keyify.Unit.Test.ScaleDictionary.UnitTests
{
    public class DuplicateModeDefinitionUnitTest
    {
        private static List<ModeDefinition> _scaleEntries = new ModeDefinitionService().GetModeDefinitions();

        [Fact(Skip = "")]
        public void NoDuplicateModeDefinitionsByScaleDegrees()
        {
            var scaleSteps = _scaleEntries.Select(s => string.Join(",", s.ScaleDegrees));
            var scaleStepDuplicates = scaleSteps.GroupBy(g => g).Where(s => s.Count() > 1);

            Assert.False(scaleStepDuplicates.Any());
        }

        [Fact(Skip = "")]
        public void NoDuplicateModeDefinitionsByScaleSteps()
        {
            var scaleSteps = _scaleEntries.Select(s => string.Join(",", s.ScaleSteps));
            var scaleStepDuplicates = scaleSteps.GroupBy(g => g).Where(s => s.Count() > 1);

            Assert.False(scaleStepDuplicates.Any());
        }
    }
}
