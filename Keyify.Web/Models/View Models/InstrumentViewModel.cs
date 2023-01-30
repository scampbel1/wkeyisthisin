using Keyify.Models.Interfaces;
using Keyify.Models.Service;
using Keyify.Models.View_Models.Misc;
using Keyify.Service.Interfaces;
using Keyify.Web.Models.Tunings;
using KeyifyWebClient.Models.Instruments;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace KeyifyWebClient.Models.ViewModels
{
    //Be careful renaming this class! (It may not rename the reference in the Views)
    public partial class InstrumentViewModel
    {
        //TODO: Find a way to update ViewTitle using ajax
        //      -->  {InstrumentName} - {SelectedScale?.UserReadableLabelIncludingColloquialism_Sharp}
        public string ViewTitle => $"What Key Is This In?";

        public List<InstrumentNote> Notes { get; } = new List<InstrumentNote>();
        public string InstrumentName { get; set; } = "Instrument Not Named";

        public List<InstrumentNote> SelectedNotes => Notes.Where(n => n.Selected).ToList();
        public string SelectedNotesJson => JsonSerializer.Serialize(SelectedNotes.Select(n => n.Note.ToString()));

        public List<InstrumentNote> UnselectedNotes => Notes.Where(n => !n.Selected).ToList();
        public List<InstrumentNote> NotesPartOfScale => Notes.Where(n => n.InSelectedScale).ToList();

        public Fretboard Fretboard { get; private set; }
        public ScaleEntry SelectedScale { get; set; }
        public List<ScaleEntry> Scales { get; set; } = new List<ScaleEntry>();

        public string AvailableKeysAndScalesLabel => GetAvailableKeysAndScalesLabel();

        private IScalesGroupingService _groupedScalesService { get; init; }

        private List<ScaleGroupingEntry> AvailableKeyGroups => _groupedScalesService.GetGroupedKeys();
        private List<ScaleGroupingEntry> AvailableScaleGroups => _groupedScalesService.GetGroupedScales();

        protected IScaleService DictionaryService { get; init; }
        protected IModeService ScaleDirectoryService { get; init; }

        public InstrumentViewModel(IScaleService dictionaryService, IModeService scaleDirectoryService, IScalesGroupingService scalesGroupingService)
        {
            DictionaryService = dictionaryService;
            ScaleDirectoryService = scaleDirectoryService;
            _groupedScalesService = scalesGroupingService;
            Notes = PopulateSelectedNotesList();
        }

        public void UpdateViewModel(string instrumentName, Tuning tuning, int fretCount)
        {
            //TODO: Stop creating a new fretboard everytime
            Fretboard = new Fretboard(tuning, fretCount);
            InstrumentName = instrumentName;
        }

        public void ProcessNotesAndScale(string selectedScale, IEnumerable<string> selectedNotes)
        {
            UpdateSelectedNotes(selectedNotes);

            if (SelectedNotes.Count > 2)
            {
                Scales = DictionaryService.FindScales(SelectedNotes.Select(a => a.Note)).ToList();
                _groupedScalesService.UpdateScaleGroupingModel(Scales, selectedNotes);
            }
            else
            {
                if (Scales != null && Scales.Any(a => a.Selected))
                {
                    Scales.SingleOrDefault(a => a.Selected).Selected = false;
                }

                Scales.Clear();

                ResetNotesInScale();

                SelectedScale = null;

                if (!selectedNotes.Any())
                {
                    ResetSelectedNotes();
                }
            }

            ApplySelectedScales(selectedScale);

            ApplySelectedNotesToFretboard();
        }
    }
}