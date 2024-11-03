using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Web.Services.Interfaces
{
    public interface IScaleGroupingHtmlService
    {
        public string GenerateKeysAndScalesTable(
            IEnumerable<Note> selectedNotes,
            InstrumentType instrumentType,
            List<ScaleGroupingEntry> availableKeyGroups,
            List<ScaleGroupingEntry> availableScaleGroups,
            string selectedString);
    }
}
