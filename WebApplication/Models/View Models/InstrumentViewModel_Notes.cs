using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyWebClient.Models.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyWebClient.Models.ViewModels
{
    public partial class InstrumentViewModel
    {
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
            var fretboardNotes = new List<InstrumentNote>(EnumHelper.GetEnumNameCount(typeof(Note)));

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

            //TODO: This should happen when you're building the fretboard, the strings are being constructed... and then reiterated over... the first step is wasteful

            foreach (InstrumentString guitarString in Fretboard.InstrumentStrings)
            {
                foreach (InstrumentNote instrumentNote in guitarString.Notes)
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
