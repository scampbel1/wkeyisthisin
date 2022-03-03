using Keyify.Models.Interfaces;
using Keyify.Models.Service;
using Keyify.Models.View_Models.Misc;
using Keyify.Service.Interface;
using KeyifyClassLibrary.Models.Interfaces;
using KeyifyWebClient.Models.Instruments;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace KeyifyWebClient.Models.ViewModels
{
    //Be careful renaming this class! (It may not rename the reference in the Views)
    public partial class InstrumentViewModel
    {
        public List<InstrumentNote> Notes { get; } = new List<InstrumentNote>();
        public string InstrumentName { get; set; } = "Instrument Not Named";

        public List<InstrumentNote> SelectedNotes => Notes.Where(n => n.Selected).ToList();
        public string SelectedNotesJson => JsonSerializer.Serialize(SelectedNotes.Select(n => n.Note.ToString()));

        public List<InstrumentNote> UnselectedNotes => Notes.Where(n => !n.Selected).ToList();
        public List<InstrumentNote> NotesPartOfScale => Notes.Where(n => n.InSelectedScale).ToList();

        public Fretboard Fretboard { get; private set; }
        public ScaleEntry SelectedScale { get; set; }
        public List<ScaleEntry> Scales { get; set; } = new List<ScaleEntry>();

        public string AvailableScalesLabel => GetAvailableScaleLabel();
        public string AvailableKeysLabel => GetAvailableKeysLabel();

        private IScalesGroupingService _groupedScalesService { get; init; }

        private List<ScaleGroupingEntry> AvailableKeyGroups => _groupedScalesService.GetGroupedKeys();
        private List<ScaleGroupingEntry> AvailableScaleGroups => _groupedScalesService.GetGroupedScales();

        protected IScaleListService DictionaryService { get; init; }
        protected IModeDefinitionService ScaleDirectoryService { get; init; }

        public InstrumentViewModel(IScaleListService dictionaryService, IModeDefinitionService scaleDirectoryService, IScalesGroupingService scalesGroupingService)
        {
            DictionaryService = dictionaryService;
            ScaleDirectoryService = scaleDirectoryService;
            _groupedScalesService = scalesGroupingService;
            Notes = PopulateSelectedNotesList();
        }

        public void UpdateViewModel(string instrumentName, ITuning tuning, int fretCount)
        {
            //TODO: Stop creating a new fretboard everytime
            Fretboard = new Fretboard(tuning, fretCount);
            InstrumentName = instrumentName;
        }        

        public void ProcessNotesAndScale(string selectedScale, IEnumerable<string> selectedNotes)
        {
            UpdateSelectedNotes(selectedNotes);

            if (SelectedNotes.Count > 1)
            {
                Scales = DictionaryService.FindScales(SelectedNotes.Select(a => a.Note)).ToList();
                _groupedScalesService.UpdateScaleGroupingModel(Scales);
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