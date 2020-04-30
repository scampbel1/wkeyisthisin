using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using KeyifyClassLibrary.Core.Instrument;
using KeyifyClassLibrary.Core.MusicTheory;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;
using KeyifyClassLibrary.Core.MusicTheory.Tuning.Guitar;

namespace KeyifyWebClient.Core.Models
{
    public class FretboardWebModel
    {
        private int _fretCount = 24;
        private readonly int _minFretCount = 8;

        public Fretboard Tuning { get; private set; }
        public Dictionary<string, bool> Notes;
        public List<ScaleMatch> Scales;
        public ScaleDictionaryEntry SelectedScale { get; set; }
        public HashSet<Note> SelectedNoteSelectedScaleMatch { get; set; }

        public FretboardWebModel()
        {
            Notes = new Dictionary<string, bool>();
            Scales = new List<ScaleMatch>();
            Tuning = new Fretboard() { new GuitarString(new StandardGuitarTuning(), _fretCount) };
            PopulateNotes();
        }

        private void PopulateNotes()
        {
            foreach (var note in (Note[])Enum.GetValues(typeof(Note)))
            {
                Notes.Add(ElementStringConverter.ConvertNoteToStringEquivalent(note, true), false);
            }
        }

        public bool NoteIsSelected(string note)
        {
            return Notes.Contains(new KeyValuePair<string, bool>(note, true));
        }

        //Improve model - wasteful use of resources
        public bool SelectedNoteIsPartOfSelectedScale(string note)
        {
            if (SelectedScale == null)
                return false;

            return SelectedNoteSelectedScaleMatch.Contains(ElementStringConverter.ConvertStringNoteToNoteType(note));
        }
        
        //Improve model - wasteful use of resources
        public bool NoteIsPartOfSelectedScale(string note)
        {
            if (SelectedScale == null)
                return false;

            return SelectedScale.Scale.NotesSet.Contains(ElementStringConverter.ConvertStringNoteToNoteType(note));
        }

        //TODO: Create unit tests and test using UI
        public void UpdateFretCount(int count)
        {
            _fretCount = count > _minFretCount
                ? _fretCount = count
                : _fretCount;

            //Tuning = Fretboard.PopulateFretboard(new StandardGuitarTuning(), _fretCount);
            PopulateNotes();
        }

        public int GetFretCount()
        {
            return _fretCount;
        }
    }
}