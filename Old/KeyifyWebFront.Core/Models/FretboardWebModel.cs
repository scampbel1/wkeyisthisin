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
        public List<string[]> Tuning { get; private set; }
        private int _fretcount = 24;

        public Dictionary<string, bool> Notes;
        public List<ScaleMatch> Scales;

        public FretboardWebModel()
        {
            Notes = new Dictionary<string, bool>();
            Scales = new List<ScaleMatch>();
            Tuning = Fretboard.PopulateFretboard(new StandardGuitarTuning(), _fretcount);
            PopulateNotes();
        }

        private void PopulateNotes()
        {
            foreach (var note in (Note[])Enum.GetValues(typeof(Note)))
            {
                Notes.Add(KeyifyElementStringConverter.ConvertNoteToStringEquivalent(note, true), false);
            }
        }

        public bool NoteIsSelected(string note)
        {
            var selectedNotes = Notes.ToImmutableHashSet().Where(a => a.Value);

            return selectedNotes.Contains(new KeyValuePair<string, bool>(note, true));
        }

        //TODO: Create unit tests and test using UI
        public void UpdateFretCount(int count)
        {
            _fretcount = count > 8 ? _fretcount = count : _fretcount;
            Tuning = Fretboard.PopulateFretboard(new StandardGuitarTuning(), _fretcount);
            PopulateNotes();
        }

        public int GetFretboardCount()
        {
            return _fretcount;
        }
    }
}