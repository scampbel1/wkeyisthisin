using Keyify.Models.Service;
using Keyify.Models.View_Models.Misc;
using System.Collections.Generic;

namespace Keyify.Models.Interfaces
{
    public interface IScalesGroupingService
    {
        void UpdateScaleGroupingModel(List<ScaleEntry> scales, IEnumerable<string> notes);
        List<ScaleGroupingEntry> GroupedKeys { get; }
        List<ScaleGroupingEntry> GroupedScales { get; }

        int TotalScaleCount { get; }

        int TotalKeyCount { get; }
    }
}
