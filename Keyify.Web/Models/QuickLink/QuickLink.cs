using Keyify.Web.Enums;
using Keyify.Web.Enums.Tuning;
using KeyifyClassLibrary.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Web.Models.QuickLink
{
    public class QuickLink : IEquatable<QuickLink>
    {
        public InstrumentType InstrumentType { get; set; }

        public GuitarTuning Tuning { get; set; }

        public Note[] SelectedNotes { get; set; }

        public string SelectedScale { get; set; }

        public string InstrumentName => InstrumentType.ToString();

        public bool Equals(QuickLink other)
        {
            var quickLinkParameters = GetHashCode();
            var otherQuickLinkParameters = other.GetHashCode();

            return quickLinkParameters == otherQuickLinkParameters;
        }

        public static bool operator ==(QuickLink a, QuickLink b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(QuickLink a, QuickLink b)
        {
            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as QuickLink);
        }

        public override int GetHashCode()
        {
            var hashCode = 17;

            hashCode = hashCode * 23 + InstrumentType.GetHashCode();
            hashCode = hashCode * 23 + Tuning.GetHashCode();
            hashCode = hashCode * 23 + ((IStructuralEquatable)SelectedNotes.OrderBy(n => n).ToArray()).GetHashCode(EqualityComparer<Note>.Default);
            hashCode = hashCode * 23 + SelectedScale.GetHashCode();

            return hashCode;
        }
    }
}
