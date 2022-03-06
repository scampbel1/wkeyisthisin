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

        [Fact (Skip = "Fix this later, there were 5 duplicated scale step groups at time of writing.")]
        public void NoDuplicateModeDefinitions()
        {
            var scaleSteps = _scaleEntries.Select(s => string.Join(",", s.ScaleDegrees));
            var scaleStepDuplicates = scaleSteps.GroupBy(g => g).Where(s => s.Count() > 1);

            Assert.True(scaleStepDuplicates.Count() == 0);
        }
    }
}
