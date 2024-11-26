using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Keyify.Models.Service
{
    public class ScaleService : IScaleService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IScaleDefinitionService _scaleDefinitionService;
        private readonly INoteFormatService _noteFormatService;

        private List<ScaleEntry> _scaleList = new List<ScaleEntry>();
        private readonly Dictionary<Note, string> _sharpNoteDictionary;

        public List<ScaleEntry> Scales => _scaleList;

        public ScaleService(
            IMemoryCache memoryCache,
            IScaleDefinitionService scaleDefinitionService,
            INoteFormatService noteFormatService)
        {
            _memoryCache = memoryCache;
            _scaleDefinitionService = scaleDefinitionService;
            _noteFormatService = noteFormatService;

            _sharpNoteDictionary = _noteFormatService.SharpNoteDictionary;

            InitialiseScaleDefinitionService();
        }

        public IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes)
        {
            var scaleList = GenerateScaleList();

            return scaleList.Where(a => a.Scale.NoteSet.IsSupersetOf(selectedNotes));
        }

        public void InitialiseScaleDefinitionService()
        {
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
                {
                    noteNumber -= 12;
                }

                var note = (Note)noteNumber;

                notes.Add(note);
                sharpNotes.Add(_sharpNoteDictionary[note]);
            }

            return new GeneratedScale(
                rootNote,
                sharpRootNote,
                notes,
                noteSetSharp: sharpNotes,
                modeDefinition.Name,
                modeDefinition.Degrees,
                modeDefinition.Popularity);
        }
    }
}