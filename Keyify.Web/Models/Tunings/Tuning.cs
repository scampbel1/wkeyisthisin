using Keyify.MusicTheory.Enums;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Keyify.Web.Models.Tunings
{
    public abstract class Tuning : IEquatable<Tuning>
    {
        public abstract Note[] Notes { get; }
        public abstract int StringCount { get; }

        public bool Equals(Tuning other)
        {
            if (other is null)
            {
                return false;
            }

            var notesHashcode = GetHashCode();
            var otherNotesHashcode = other.GetHashCode();

            return notesHashcode == otherNotesHashcode;
        }

        public override int GetHashCode()
        {
            var hashCode = 17;

            hashCode = hashCode * 23 + ((IStructuralEquatable)Notes).GetHashCode(EqualityComparer<Note>.Default);

            return hashCode;
        }
    }
}