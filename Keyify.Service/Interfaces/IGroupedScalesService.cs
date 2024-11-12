using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Web.Service.Interfaces
{
    public interface IGroupedScalesService
    {
        void UpdateScaleGroupingModel(IEnumerable<ScaleEntry> scaleEntries, IEnumerable<Note> notes);

        List<ScaleGroupingEntry> GroupedScales { get; }
    }
}
