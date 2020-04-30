using System.Collections.Generic;
using KeyifyClassLibrary.Core.MusicTheory;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;
using KeyifyClassLibrary.Core.MusicTheory.Tuning.Guitar;

namespace KeyifyWebClient.Core.Models
{
    public class FretboardWebModel
    {
        private static int _fretCount = 24;
        private readonly int _minFretCount = 8;

        public Fretboard Fretboard { get; private set; }
        public List<ScaleMatch> Scales;
        public ScaleDictionaryEntry SelectedScale { get; set; }
        public List<string> SelectedNotes { get; set; }

        public FretboardWebModel()
        {
            Scales = new List<ScaleMatch>();
            Fretboard = new Fretboard(new StandardGuitarTuning(), _fretCount);
            SelectedNotes = new List<string>(12);
        }

        //TODO: Create unit tests and test using UI
        public void UpdateFretCount(int count)
        {
            _fretCount = count > _minFretCount
                ? _fretCount = count
                : _fretCount;

            //missing 

            //Tuning = Fretboard.PopulateFretboard(new StandardGuitarTuning(), _fretCount);
        }

        public int GetFretCount()
        {
            return _fretCount;
        }

        public void ApplySelectedNotesToFretboard(string[] selectedNotes)
        {
            HashSet<Note> SelectedNotes = new HashSet<Note>(ElementStringConverter.ConvertStringArrayIntoNotes(selectedNotes));

            foreach(InstrumentString guitarString in Fretboard.InstrumentStrings)
            {
                foreach(FretboardNote fretboardNote in guitarString.Notes)
                {
                    if (SelectedNotes.Contains(fretboardNote.Note))
                        fretboardNote.Selected = true;
                    else
                        fretboardNote.Selected = false;
                }
            }
        }

        public void ApplySelectedScaleNotesToFretboard(HashSet<Note> scaleNotes)
        {
            foreach (InstrumentString guitarString in Fretboard.InstrumentStrings)
            {
                foreach (FretboardNote fretboardNote in guitarString.Notes)
                {
                    if (scaleNotes.Contains(fretboardNote.Note))
                        fretboardNote.InSelectedScale = true;
                    else
                        fretboardNote.InSelectedScale = false;
                }
            }
        }
    }
}