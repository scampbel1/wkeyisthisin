﻿using Keyify.MusicTheory.Enums;
using System.Collections;
using System.Text;

namespace Keyify.Services.Models
{
    public class ChordDefinition : IEquatable<ChordDefinition>
    {
        public readonly int Id;
        public readonly string Type;
        public readonly Note[] Notes;
        public readonly string Name = string.Empty;
        public readonly int Popularity = 3;

        public string Label => GenerateLabel(Name);

        public ChordDefinition(
            string chordType,
            Note[] notes,
            int popularity = 3)
        {
            Type = chordType;
            Notes = notes;
            Name = $"{notes[0]} {chordType}";
            Popularity = popularity;
        }

        public ChordDefinition(
            string chordType,
            Note[] notes,
            string rootNote,
            int popularity = 3) : this(chordType, notes, popularity)
        {
            Name = $"{rootNote} {chordType}";
        }

        public bool IsSupersetOf(Note[] selectedNotes)
        {
            return selectedNotes.ToHashSet().IsSupersetOf(Notes);
        }

        public bool Equals(ChordDefinition? other)
        {
            if (other is null)
            {
                return false;
            }

            var notesHashcode = GetHashCode();
            var otherNotesHashcode = other.GetHashCode();

            return notesHashcode == otherNotesHashcode;
        }

        public static bool operator ==(ChordDefinition a, ChordDefinition b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ChordDefinition a, ChordDefinition b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            var hashCode = 17;

            hashCode = hashCode * 23 + Type.GetHashCode();
            hashCode = hashCode * 23 + ((IStructuralEquatable)Notes).GetHashCode(EqualityComparer<Note>.Default);

            return hashCode;
        }

        //TODO: Boilerplate code - move to service or define in database or both
        private string GenerateLabel(string label)
        {
            var count = 1;
            var sb = new StringBuilder().Append(label);

            while (count < sb.Length - 1)
            {
                if (char.IsUpper(sb[count]) && sb[count - 1] != ' ')
                {
                    sb.Insert(count, ' ');
                }
                else if (sb[count] == '_')
                {
                    sb[count] = ' ';
                }

                count++;
            }

            return sb.ToString();
        }

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj)
        {
            return Equals(obj as ChordDefinition);
        }
    }
}
