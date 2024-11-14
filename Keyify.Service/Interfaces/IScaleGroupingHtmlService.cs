using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Web.Services.Interfaces
{
    public interface IScaleGroupingHtmlService
    {
        public string GenerateScalesTable(
            IEnumerable<Note> selectedNotes,
            InstrumentType instrumentType,
            List<ScaleGroupingEntry> limitedScaleGroups,
            string selectedString);
    }
}
