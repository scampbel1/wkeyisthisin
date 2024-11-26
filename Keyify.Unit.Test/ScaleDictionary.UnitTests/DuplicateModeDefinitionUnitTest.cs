using Keyify.Models.Service;
using Keyify.Services.Models;
using Keyify.Web.Unit.Test.ChordTemplates.UnitTests.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keyify.Unit.Test.ScaleDictionary.UnitTests
{
    public class DuplicateModeDefinitionUnitTest
    {
        private List<ScaleDefinition> _scaleEntries;
        private const string _scaleDefinitionsCacheKey = "ScaleDefinitions";

        public DuplicateModeDefinitionUnitTest()
        {
            var cache = new MockScaleDefinitionCache();
            Task.WhenAny(cache.InitializeCacheAsync());

            _scaleEntries = new ScaleDefinitionService(cache, new MockScaleDefinitionRepository()).ScaleDefinitions;
        }

        [Fact]
        public void NoDuplicateModeDefinitionsByScaleDegrees()
        {
            var scaleDegrees = _scaleEntries.Select(s => string.Join(",", s.Degrees));
            var scaleDegreeDuplicates = scaleDegrees.GroupBy(g => g).Where(s => s.Count() > 1);

            var duplicateNames = GetDuplicateModeNamesByScaleDegree(scaleDegreeDuplicates);

            Assert.False(scaleDegreeDuplicates.Any(), $"Duplicates found: {string.Join(", ", duplicateNames.Select(d => d.Key))}");
        }

        [Fact]
        public void NoDuplicateModeDefinitionsByScaleIntervals()
        {
            var scaleIntervals = _scaleEntries.Select(s => string.Join(",", s.Intervals));
            var scaleIntervalDuplicates = scaleIntervals.GroupBy(g => g).Where(s => s.Count() > 1);

            var duplicateNames = GetDuplicateModeNamesByScaleIntervals(scaleIntervalDuplicates);

            Assert.False(scaleIntervalDuplicates.Any(), $"Duplicates found: {string.Join(", ", duplicateNames.Select(d => d.Key))}");
        }

        private Dictionary<string, string> GetDuplicateModeNamesByScaleDegree(IEnumerable<IGrouping<string, string>> scaleDegreeDuplicates)
        {
            var duplicateNames = new Dictionary<string, string>();

            foreach (var duplicate in scaleDegreeDuplicates.ToList())
            {
                var duplicateNotesSet = duplicate.Key;

                var duplicateModes = _scaleEntries
                    .Where(e => string.Join(",", e.Degrees) == duplicateNotesSet)
                    .Select(n => n.Name);

                foreach (var duplicateMode in duplicateModes)
                {
                    duplicateNames.Add(duplicateMode, duplicateNotesSet);
                }
            }

            return duplicateNames;
        }

        private Dictionary<string, string> GetDuplicateModeNamesByScaleIntervals(IEnumerable<IGrouping<string, string>> scaleIntervalDuplicates)
        {
            var duplicateNames = new Dictionary<string, string>();

            foreach (var duplicate in scaleIntervalDuplicates.ToList())
            {
                var duplicateNotesSet = duplicate.Key;

                var duplicateModes = _scaleEntries
                    .Where(e => string.Join(",", e.Intervals) == duplicateNotesSet)
                    .Select(n => n.Name);

                foreach (var duplicateMode in duplicateModes)
                {
                    duplicateNames.Add(duplicateMode, duplicateNotesSet);
                }
            }

            return duplicateNames;
        }
    }
}
