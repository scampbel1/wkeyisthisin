using Keyify.Models.ViewModels.Misc;
using Keyify.Web.Enums;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Web.Service.Interfaces
{
    public interface IScaleGroupingHtmlService
    {
        public string GenerateAvailableKeysAndScalesTable(IEnumerable<Note> selectedNotes, InstrumentType instrumentType, List<ScaleGroupingEntry> availableKeyGroups, List<ScaleGroupingEntry> availableScaleGroups);
    }
}
