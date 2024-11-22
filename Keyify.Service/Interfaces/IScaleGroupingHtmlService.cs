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

        public (string, string) GetScalePopularityIcon(int popularity);

        public string GenerateNotesGroupingLabelHtml(
            IEnumerable<Note> selectedNotes,
            List<ScaleEntry> groupedScales);
    }
}
