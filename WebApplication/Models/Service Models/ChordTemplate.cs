using Keyify.Enums;
using KeyifyClassLibrary.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Keyify.Models.Service_Models
{
    public class ChordTemplate : IEquatable<ChordTemplate>
    {
        public readonly ChordType ChordType;
        public readonly Note[] Notes;

        public ChordTemplate(ChordType chordType, Note[] notes)
        {
            ChordType = chordType;
            Notes = notes;
        }

        public bool Equals(ChordTemplate other)
        {
            var notesHashcode = ((IStructuralEquatable)Notes).GetHashCode(EqualityComparer<Note>.Default);
            var otherNotesHashcode = ((IStructuralEquatable)other.Notes).GetHashCode(EqualityComparer<Note>.Default);

            return (ChordType == other.ChordType) && notesHashcode == otherNotesHashcode;
        }
    }
}
