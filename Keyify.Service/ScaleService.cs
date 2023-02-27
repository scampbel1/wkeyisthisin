using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Models;

namespace Keyify.Models.Service
{
    public class ScaleService : IScaleService
    {
        private readonly IScaleDefinitionService _modeService;
        private readonly INoteFormatService _noteFormatService;

        private readonly List<ScaleEntry> _scaleList;
        private readonly Dictionary<Note, string> _sharpNoteDictionary;

        public List<ScaleEntry> Scales => _scaleList;

        public ScaleService(IScaleDefinitionService modeService, INoteFormatService noteFormatService)
        {
            _modeService = modeService;
            _noteFormatService = noteFormatService;

            _sharpNoteDictionary = _noteFormatService.SharpNoteDictionary;
            _scaleList = GenerateScaleList();
        }

        public IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes)
        {
            return _scaleList.Where(a => a.Scale.NoteSet.IsSupersetOf(selectedNotes));
        }

        private List<ScaleEntry> GenerateScaleList()
        {
            return GetScaleEntries(_modeService.ScaleDefinitions);
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

            foreach (var scaleStep in modeDefinition.ScaleIntervals)
            {
                noteNumber += (int)scaleStep;

                if (noteNumber > 11)
                    noteNumber -= 12;

                var note = (Note)noteNumber;

                notes.Add(note);
                sharpNotes.Add(_sharpNoteDictionary[note]);
            }

            return new GeneratedScale(rootNote, sharpRootNote, notes, sharpNotes, modeDefinition.Mode, modeDefinition.ScaleDegrees);
        }
    }
}