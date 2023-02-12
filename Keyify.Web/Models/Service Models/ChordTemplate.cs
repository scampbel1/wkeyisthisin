using Keyify.Enums;
using KeyifyClassLibrary.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keyify.Models.ServiceModels
{
    public class ChordTemplate : IEquatable<ChordTemplate>
    {
        public readonly ChordType Type;
        public readonly Note[] Notes;
        public readonly string Name = string.Empty;

        public string Label => GenerateLabel(Name);

        public ChordTemplate(ChordType chordType, Note[] notes)
        {
            Type = chordType;
            Notes = notes;
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
            var hashCode = 17;

            hashCode = hashCode * 23 + Type.GetHashCode();
            hashCode = hashCode * 23 + ((IStructuralEquatable)Notes).GetHashCode(EqualityComparer<Note>.Default);

            return hashCode;
        }

        //TODO: Boilerplate code - move to service or define in database or both
        private string GenerateLabel(string label)
        {
            var sb = new StringBuilder().Append(label);
            int count = 1;

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
    }
}
