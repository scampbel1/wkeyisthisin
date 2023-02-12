using KeyifyClassLibrary.Enums;
using KeyifyWebClient.Models.ViewModels;
using System.Collections.Generic;

namespace Keyify.Web.Service.Interfaces
{
    public interface IFretboardService
    {
        void UpdateFretboard(InstrumentViewModel viewModel);

        void UpdateViewModel(InstrumentViewModel viewModel, IEnumerable<Note> selectedNotes, string selectedScale);
    }
}
