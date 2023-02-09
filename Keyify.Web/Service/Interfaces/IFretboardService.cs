using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using KeyifyWebClient.Models.Instruments;
using KeyifyWebClient.Models.ViewModels;
using System.Collections.Generic;

namespace Keyify.Web.Service.Interfaces
{
    public interface IFretboardService
    {
        void ApplyNotesToFretboard(Fretboard fretboard, IEnumerable<FretboardNote> instrumentNotes, ScaleEntry selectedScale);

        void ProcessNotesAndScale(InstrumentViewModel viewModel, IEnumerable<Note> selectedNotes, string selectedScale);
    }
}
