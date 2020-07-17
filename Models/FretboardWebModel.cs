using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Tuning;
using KeyifyClassLibrary.Core.Domain.Tuning.Guitar;
using System.Collections.Generic;

namespace KeyifyWebClient.Core.Models
{
    public class FretboardWebModel
    {
        public string InstrumentName { get; set; } = "Unnamed Instrument";
        public Fretboard Fretboard { get; private set; }
        public ScaleDictionaryEntry SelectedScale { get; set; }
        public List<string> SelectedNotes { get; set; }
        public List<ScaleDictionaryEntry> Scales;

        public FretboardWebModel()
        {
            Scales = new List<ScaleDictionaryEntry>();
            Fretboard = new Fretboard(new StandardGuitarTuning(), 24);
            SelectedNotes = new List<string>(12);
        }

        public FretboardWebModel(int fretCount, ITuning tuning)
        {
            Scales = new List<ScaleDictionaryEntry>();
            Fretboard = new Fretboard(tuning, fretCount);
            SelectedNotes = new List<string>(12);
        }

        public int GetFretCount()
        {
            return Fretboard.FretCount;
        }

        public void ApplySelectedNotesToFretboard(List<Note> selectedNotes, HashSet<Note> scaleNotes)
        {
            foreach (InstrumentString guitarString in Fretboard.InstrumentStrings)
            {
                foreach (FretboardNote fretboardNote in guitarString.Notes)
                {
                    if (selectedNotes.Contains(fretboardNote.Note))
                        fretboardNote.Selected = true;
                    else
                        fretboardNote.Selected = false;

                    if (scaleNotes != null)
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
}