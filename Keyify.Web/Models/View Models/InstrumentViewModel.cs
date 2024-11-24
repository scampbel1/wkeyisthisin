using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using Keyify.Web.Models.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Keyify.Web.Models.ViewModels
{
    public partial class InstrumentViewModel
    {
        private readonly Dictionary<Note, string> _sharpNotesDictionary;

        public InstrumentViewModel(Fretboard fretboard)
        {
            Fretboard = fretboard;
            _sharpNotesDictionary = fretboard.SharpNotesDictionary;
            NotesMatrix = InitialiseNotesMatrix();
        }

        private List<FretboardNote> NotesMatrix { get; } = new List<FretboardNote>();

        public string ViewTitle { get; } = "Notes to Key";

        public string QuickLinkCode { get; private set; }

        public bool IsSelectionLocked { get; set; }

        public string IsSelectionLockedJson => IsSelectionLocked.ToString().ToLower();

        public Fretboard Fretboard { get; set; }

        public ScaleEntry SelectedScale { get; set; }

        public List<ScaleEntry> Scales { get; set; } = new List<ScaleEntry>();

        public List<ChordDefinition> ChordDefinitions { get; set; } = new List<ChordDefinition>();

        public void UpdateViewModel(Fretboard fretboard) => Fretboard = fretboard;

        public void UpdateQuickLinkCode(string quickLinkCode) => QuickLinkCode = quickLinkCode;

        public void UpdateAvailableScalesTableHtml(string htmlContent) => AvailableKeysAndScalesTableHtml = htmlContent;

        public void UpdateAvailableChordDefinitionsHtml(string htmlContent) => AvailableChordDefinitionsTableHtml = htmlContent;

        public string SelectedNotesJson
        {
            get
            {
                var selectedNoteArray = SelectedNotes
                    .Select(n => n.Note.ToString());

                return JsonSerializer.Serialize(selectedNoteArray);
            }
        }

        public string AvailableKeysAndScalesTableHtml { get; private set; }

        public string AvailableChordDefinitionsTableHtml { get; private set; }

        public string LockedScale => $"Fretboard is locked to: {SelectedScale.FullName_Sharp}";

        public string AvailableKeysAndScalesLabel => AvailableScaleGroups.Any() ?
            $"{ScalesFoundText} {GetAvailableKeysLabel()}" :
            SelectionMessage;

        private string SelectionMessage => SelectedNotes.Count < 3 ?
            $"Select 3 or More Notes ({3 - SelectedNotes.Count} more to go!)" :
             "No Scales Found";

        public string ScalePopularityIconLegend { get; set; }

        public string ChordPopularityIconLegend { get; set; }

        public string LockChordHtml
        {
            get
            {
                if (SelectedScale is null || ChordDefinitions is null)
                {
                    return string.Empty;
                }

                var lockText = IsSelectionLocked ?
                    string.Empty :
                    "Lock";

                var isFretboardUnlocked = $"{!IsSelectionLocked}".ToLower();

                var onclick = $"UpdateModel('/{Fretboard.InstrumentType.ToString()}/UpdateFretboardModel', " +
                    $"'{SelectedScale.ScaleLabel}', " +
                    $"null, " +
                    $"{SelectedNotesJson.Replace("\"", "\'")} , " +
                    $"{isFretboardUnlocked})";

                var lockEmojiIcon = IsSelectionLocked ?
                    "&#128274;" :
                    "&#128275;";

                var chordsFoundMessage = IsSelectionLocked ?
                    string.Empty :
                    $"{ChordDefinitions?.Count ?? 0} Chords found!";

                var scaleLabel = IsSelectionLocked ?
                    "Unlock" :
                    SelectedScale?.FullName_Sharp;

                return $"<span>{lockText} <a onclick=\"{onclick}\"><u>{scaleLabel}</u></a> " +
                    $"{lockEmojiIcon} " +
                    $"{chordsFoundMessage}</span>";
            }
        }

        private string ScalesFoundText
        {
            get
            {
                if (AvailableScaleGroups.Any())
                {
                    var groupedScaleCount = LimitedScaleGroup
                        .SelectMany(l => l.GroupedScales)
                        .Count(g => !g.IsKey);

                    return $"Showing {groupedScaleCount} of {GetAvailableScaleLabel()} - ";
                }
                else
                {
                    return "No Scales Found";
                }
            }
        }

        public List<FretboardNote> SelectedNotes => NotesMatrix.Where(n => n.Selected).ToList();

        public List<FretboardNote> UnselectedNotes => NotesMatrix.Where(n => !n.Selected).ToList();

        public List<FretboardNote> NotesPartOfScale => NotesMatrix.Where(n => n.InSelectedScale).ToList();

        public List<ScaleGroupingEntry> LimitedScaleGroup => AvailableScaleGroups.Take(18).ToList();

        public List<ScaleGroupingEntry> AvailableScaleGroups { get; set; } = new List<ScaleGroupingEntry>();

        private List<FretboardNote> InitialiseNotesMatrix()
        {
            var fretboardNotes = new List<FretboardNote>((int)Note.Ab);

            foreach (Note note in Enum.GetValues(typeof(Note)))
            {
                fretboardNotes.Add(new FretboardNote(note, _sharpNotesDictionary[note]));
            }

            return fretboardNotes;
        }

        private string GetAvailableKeysLabel()
        {
            var matchingScaleCount = Scales.Count(s => s.IsKey);
            return matchingScaleCount switch
            {
                0 => GetNoKeysFoundMessage(),
                1 => $"{matchingScaleCount} Matching Key",
                _ => $"{matchingScaleCount} Matching Keys"
            };
        }

        private string GetNoKeysFoundMessage()
        {
            var selectedNoteCount = SelectedNotes.Count;
            return selectedNoteCount switch
            {
                _ => "No Matching Keys"
            };
        }

        private string GetAvailableScaleLabel()
        {
            var matchingScaleCount = Scales.Count(s => !s.IsKey);
            return matchingScaleCount switch
            {
                0 => GetNoScalesFoundMessage(),
                1 => $"{matchingScaleCount} Matching Scale",
                _ => $"{matchingScaleCount} Matching Scales"
            };
        }

        private string GetNoScalesFoundMessage()
        {
            var selectedNoteCount = SelectedNotes.Count;
            return selectedNoteCount switch
            {
                1 => $"Only {selectedNoteCount} Note Selected",
                <= 2 => $"Only {selectedNoteCount} Notes Selected",
                _ => "No Matching Scales"
            };
        }
    }
}