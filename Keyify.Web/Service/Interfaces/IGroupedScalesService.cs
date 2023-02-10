using Keyify.Models.Service;
using Keyify.Models.ViewModels.Misc;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Web.Service.Interfaces
{
    public interface IGroupedScalesService
    {
        void UpdateScaleGroupingModel(IEnumerable<ScaleEntry> scaleEntries, IEnumerable<Note> notes);

        List<ScaleGroupingEntry> GroupedKeys { get; }

        List<ScaleGroupingEntry> GroupedScales { get; }

        int TotalScaleCount { get; }

        int TotalKeyCount { get; }
    }
}
