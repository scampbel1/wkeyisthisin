using KeyifyClassLibrary.Enums;
using KeyifyWebClient.Models.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyWebClient.Models.ViewModels
{
    public partial class InstrumentViewModel
    {
        //TODO: This can be replaced by passing in int/enum values as part of the request - conversion is needless
        private void UpdateSelectedNotes(IEnumerable<string> selectedNotes)
        {
            var noteStack = new Stack<string>(selectedNotes);

            ResetSelectedNotes();

            while (noteStack.Any())
            {
                var selectedNote = noteStack.Pop();

                UnselectedNotes.Where(n => n.Note.ToString() == selectedNote).Single().Selected = true;
            }
        }

        private void ResetSelectedNotes()
        {
            foreach (var selectedNote in SelectedNotes)
            {
                selectedNote.Selected = false;
            }
        }

        private List<InstrumentNote> PopulateSelectedNotesList()
        {
            var fretboardNotes = new List<InstrumentNote>((int)Note.Ab);

            foreach (Note note in Enum.GetValues(typeof(Note)))
            {
                fretboardNotes.Add(new InstrumentNote(note));
            }

            return fretboardNotes;
        }

        public void ApplySelectedNotesToFretboard()
        {
            if (SelectedNotes == null || !SelectedNotes.Any())
            {
                return;
            }

            /*TODO: See whether the efficiency of this can be improved upon. Can this be taken care of outside of the viewmodel, and we present the "state" of the fretboard as it exists. 
             * It seems wasteful to iterate through every note, each time there is a change in state based on user input.
             * We could easily update a matrix and simply display that matrix on the screen.
            */

            if (Fretboard != null && Fretboard.InstrumentStrings.Any())
            {
                foreach (var guitarString in Fretboard.InstrumentStrings)
                {
                    foreach (var instrumentNote in guitarString.Notes)
                    {
                        var currentNote = SelectedNotes.SingleOrDefault(s => s.Equals(instrumentNote));

                        if (currentNote != null)
                        {
                            instrumentNote.Selected = currentNote.Selected;
                        }

                        if (SelectedScale != null && SelectedScale.Scale.NoteSet.Contains(instrumentNote.Note))
                        {
                            instrumentNote.InSelectedScale = true;

                            if (instrumentNote.InSelectedScale)
                            {
                                var currentNoteIndex = SelectedScale.Scale.Notes.IndexOf(instrumentNote.Note);
                                instrumentNote.DegreeInScale = SelectedScale.Scale.ModeDefinition.ScaleDegrees[currentNoteIndex];
                            }
                        }
                    }
                }
            }
        }
    }
}
