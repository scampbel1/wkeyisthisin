using Keyify.Enums;
using KeyifyClassLibrary.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Models.Service_Models
{
    public class ChordTemplate : IEquatable<ChordTemplate>
    {
        public readonly ChordType Type;
        public readonly Note[] Notes;
        public readonly string Name = string.Empty;

        public ChordTemplate(Note[] notes)
        {
            Notes = notes;
        }

        public ChordTemplate(ChordType chordType, Note[] notes) : this(notes)
        {
            Type = chordType;
            Name = $"{notes[0]} {chordType}";
        }

        public bool IsSubsetOf(Note[] selectedNotes)
        {
            return selectedNotes.ToHashSet().IsSupersetOf(Notes);
        }

        public bool Equals(ChordTemplate other)
        {
            var notesHashcode = GetHashCode();
            var otherNotesHashcode = other.GetHashCode();

            return notesHashcode == otherNotesHashcode;
        }

        public static bool operator ==(ChordTemplate a, ChordTemplate b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ChordTemplate a, ChordTemplate b)
        {
            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ChordTemplate);
        }

        public override int GetHashCode()
        {
            //Ensures notes are in the same order
            return ((IStructuralEquatable)Notes).GetHashCode(EqualityComparer<Note>.Default);
        }
    }
}
