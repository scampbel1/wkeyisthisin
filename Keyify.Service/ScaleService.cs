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

            Task.WhenAll(Init());
        }

        public IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes)
        {
            return _scaleList.Where(a => a.Scale.NotesHashSet.IsSupersetOf(selectedNotes));
        }

        public async Task Init()
        {
            await _scaleDefinitionService.Init();

            _scaleList = GenerateScaleEntries(_scaleDefinitionService.ScaleDefinitions);

            //_scaleList.AddRange(GenerateParallelScales());
        }

        private List<ScaleEntry> GenerateScaleEntries(IEnumerable<ScaleDefinition> scaleDefinitions)
        {
            var scaleEntries = new List<ScaleEntry>();

            foreach (var scaleDefinition in scaleDefinitions)
            {
                scaleEntries.AddRange(GenerateScaleEntries(scaleDefinition));
            }

            return scaleEntries;
        }

        private List<ScaleEntry> GenerateScaleEntries(ScaleDefinition scaleDefinition)
        {
            var scaleEntry = new List<ScaleEntry>();

            if (scaleDefinition.AllowedRootNotes != null)
            {
                scaleEntry.AddRange(from Note note in scaleDefinition.AllowedRootNotes
                                    let generatedScale = CreateGeneratedScales(note, scaleDefinition)
                                    select new ScaleEntry(generatedScale));
            }

            return scaleEntry;
        }

        //private List<ScaleEntry> GenerateParallelScales()
        //{
        //    var parallelScales = new List<ScaleEntry>(_scaleList.Count(s => s.IsKey));

        //    foreach (var key in _scaleList.Where(s => s.IsKey))
        //    {
        //        var parallelScaleName = GetOppositeScaleName(key.Scale.Name);
        //        var parallelKey = _scaleList.SingleOrDefault(s => s.IsKey && s.Scale.RootNote == key.Scale.RootNote && key.Scale.Name == parallelScaleName);

        //        if (parallelKey != null)
        //        {
        //            var notesHashSet = key.Scale.NotesHashSet;

        //            notesHashSet.SymmetricExceptWith(parallelKey.Scale.NotesHashSet);

        //            //TODO: Could do with an adapter pattern here (or some way of making a clone)
        //            var generatedScale = new GeneratedScale(key.Scale.RootNote, key.Scale.SharpRootNote, new List<Note>(key.Scale.Notes).AddRange(notesHashSet), new List<string>(key.Scale.Notes))

        //            var extendedKey = new ScaleEntry()
        //        }

        //    }
        //}

        private string GetOppositeScaleName(string mode) => mode == "Ionian" ? "Aeolian" : "Ionian";

        //TODO: Move this to Factory pattern
        private GeneratedScale CreateGeneratedScales(Note rootNote, ScaleDefinition modeDefinition)
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
        
        ////TODO: Move this to Factory pattern
        //private GeneratedScale CreateParallelScale(Note rootNote, string rootNoteSharp, List<Note> notes, string name, string[] scaleDegrees)
        //{
        //    var sharpRootNote = _sharpNoteDictionary[rootNote];
        //    var sharpNotes = new List<string>();

        //    var noteNumber = (int)rootNote;

        //    foreach (var scaleStep in modeDefinition.Intervals)
        //    {
        //        noteNumber += (int)scaleStep;

        //        if (noteNumber > 11)
        //            noteNumber -= 12;

        //        var note = (Note)noteNumber;

        //        notes.Add(note);
        //        sharpNotes.Add(_sharpNoteDictionary[note]);
        //    }

        //    return new GeneratedScale(rootNote, sharpRootNote, notes, sharpNotes, modeDefinition.Name, modeDefinition.Degrees);
        //}
    }
}