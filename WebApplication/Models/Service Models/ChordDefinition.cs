using Keyify.Enums;
using KeyifyClassLibrary.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Keyify.Models.Service_Models
{
    //What does this represent? Is it too concrete? (i.e. does the scale need to be included?)
    //Can't we say, here is the Chord Type and its steps in a scale (I - V - Vi etc.) ?
    //We then use this to say, here is a chord definition, generate a definition for each chord type for each note
    public class ChordDefinition : IEquatable<ChordDefinition>
    {
        public readonly ChordType ChordType;
        public readonly Note[] Notes;

        public ChordDefinition(ChordType chordType, Note[] notes)
        {
            ChordType = chordType;
            Notes = notes;
        }

        public bool Equals(ChordDefinition other)
        {
            var notesHashcode = ((IStructuralEquatable)Notes).GetHashCode(EqualityComparer<Note>.Default);
            var otherNotesHashcode = ((IStructuralEquatable)other.Notes).GetHashCode(EqualityComparer<Note>.Default);

            return (ChordType == other.ChordType) && notesHashcode == otherNotesHashcode;
        }
    }
}
