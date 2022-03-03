using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyifyWebClient.Models.ViewModels
{
    public partial class InstrumentViewModel
    {
        private void ApplySelectedScales(string selectedScale)
        {
            ResetSelectedScales();

            if (!string.IsNullOrWhiteSpace(selectedScale))
            {
                SelectedScale = Scales.SingleOrDefault(a => a.ScaleLabel == selectedScale);

                if (SelectedScale != null)
                {
                    SelectedScale.Selected = true;
                    return;
                }

                SelectedScale = null;
            }
            else
            {
                SelectedScale = null;
            }
        }

        private void ResetNotesInScale()
        {
            foreach (var selectedNote in NotesPartOfScale)
            {
                selectedNote.InSelectedScale = false;
            }
        }

        private void ResetSelectedScales()
        {
            foreach (var selectedScale in Scales.Where(s => s.Selected))
            {
                selectedScale.Selected = false;
            }
        }
    }
}
