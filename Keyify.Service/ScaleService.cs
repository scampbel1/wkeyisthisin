using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Models;

namespace Keyify.Models.Service
{
    public class ScaleService : IScaleService
    {
        private readonly IScaleDefinitionService _scaleDefinitionService;
        private readonly INoteFormatService _noteFormatService;

        private List<ScaleEntry> _scaleList = new List<ScaleEntry>();
        private readonly Dictionary<Note, string> _sharpNoteDictionary;

        public List<ScaleEntry> Scales => _scaleList;

        public ScaleService(IScaleDefinitionService scaleDefinitionService, INoteFormatService noteFormatService)
        {
            _scaleDefinitionService = scaleDefinitionService;
            _noteFormatService = noteFormatService;

            _sharpNoteDictionary = _noteFormatService.SharpNoteDictionary;

            Task.WhenAll(InitialiseScaleDefinitionService());
        }

        public IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes)
        {
            return _scaleList.Where(a => a.Scale.NoteSet.IsSupersetOf(selectedNotes));
        }

        public async Task InitialiseScaleDefinitionService()
        {
            await _scaleDefinitionService.InitialiseScaleDefinitionCache();

            _scaleList = GenerateScaleList();
        }

        private List<ScaleEntry> GenerateScaleList()
        {
            return GetScaleEntries(_scaleDefinitionService.ScaleDefinitions);
        }

        private List<ScaleEntry> GetScaleEntries(IEnumerable<ScaleDefinition> modeDefinitionDictionary)
        {
            var scaleEntries = new List<ScaleEntry>();

            foreach (var modeDefinition in modeDefinitionDictionary)
            {
                scaleEntries.AddRange(GenerateScaleEntries(modeDefinition));
            }

            return scaleEntries;
        }

        private List<ScaleEntry> GenerateScaleEntries(ScaleDefinition modeDefinition)
        {
            var scaleEntry = new List<ScaleEntry>();

            if (modeDefinition.AllowedRootNotes != null)
            {
                scaleEntry.AddRange(from Note note in modeDefinition.AllowedRootNotes
                                    let generatedScale = CreateGeneratedScale(note, modeDefinition)
                                    select new ScaleEntry(generatedScale));
            }

            return scaleEntry;
        }

        //TODO: Move this to Factory pattern
        private GeneratedScale CreateGeneratedScale(Note rootNote, ScaleDefinition modeDefinition)
        {
            var notes = new List<Note>();
            var sharpRootNote = _sharpNoteDictionary[rootNote];
            var sharpNotes = new List<string>();

            var noteNumber = (int)rootNote;

            foreach (var scaleStep in modeDefinition.Intervals)
            {
                noteNumber += (int)scaleStep;

                if (noteNumber > 11)
                    noteNumber -= 12;

                var note = (Note)noteNumber;

                notes.Add(note);
                sharpNotes.Add(_sharpNoteDictionary[note]);
            }

            return new GeneratedScale(rootNote, sharpRootNote, notes, sharpNotes, modeDefinition.Name, modeDefinition.Degrees);
        }
    }
}