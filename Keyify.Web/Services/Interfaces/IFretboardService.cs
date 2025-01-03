﻿using Keyify.MusicTheory.Enums;
using Keyify.Web.Models.ViewModels;
using System.Collections.Generic;

namespace Keyify.Web.Services.Interfaces
{
    public interface IFretboardService
    {
        void UpdateUnlockedFretboard(InstrumentViewModel viewModel);

        void UpdateViewModel(
            InstrumentViewModel viewModel,
            IEnumerable<Note> selectedNotes,
            string selectedScale,
            InstrumentType instrumentType);
    }
}
