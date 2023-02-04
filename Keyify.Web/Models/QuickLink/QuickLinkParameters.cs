using Keyify.Web.Enums;
using Keyify.Web.Enums.Tuning;
using KeyifyClassLibrary.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Keyify.Web.Models.QuickLink
{
    public class QuickLinkParameters : IEquatable<QuickLinkParameters>
    {
        public InstrumentType InstrumentType { get; set; }

        public GuitarTuning Tuning { get; set; }

        public Note[] SelectedNotes { get; set; }

        public string SelectedScale { get; set; }

        public string Base64 => GenerateBase64Representation();

        private string GenerateBase64Representation()
        {
            var parametersJson = JsonSerializer.Serialize(GetHashCode());
            var parametersJsonBytes = Encoding.Default.GetBytes(parametersJson);

            return Convert.ToBase64String(parametersJsonBytes);
        }

        public bool Equals(QuickLinkParameters other)
        {
            var quickLinkParameters = GetHashCode();
            var otherQuickLinkParameters = other.GetHashCode();

            return quickLinkParameters == otherQuickLinkParameters;
        }

        public static bool operator ==(QuickLinkParameters a, QuickLinkParameters b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(QuickLinkParameters a, QuickLinkParameters b)
        {
            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as QuickLinkParameters);
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
