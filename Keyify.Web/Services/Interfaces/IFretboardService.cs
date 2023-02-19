using Keyify.MusicTheory.Enums;
using Keyify.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keyify.Web.Services.Interfaces
{
    public interface IFretboardService
    {
        void UpdateFretboard(InstrumentViewModel viewModel);

        Task UpdateViewModel(InstrumentViewModel viewModel, IEnumerable<Note> selectedNotes, string selectedScale);
    }
}
