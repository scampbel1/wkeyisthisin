using Keyify.Helper;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyClassLibrary.Models.MusicTheory;
using System;
using System.Text;

namespace Keyify.Models.Service
{
    public class ScaleEntry : IEquatable<ScaleEntry>
    {
        public Scale Scale { get; set; }
        public bool Selected { get; set; }
        public string ScaleLabel { get; set; }
        public bool IsKey => IsScaleEntryAKey();

        private bool IsScaleEntryAKey()
        {
            return Scale.ModeDefinition.Mode == Mode.Ionian || Scale.ModeDefinition.Mode == Mode.Aeolian;
        }

        public readonly string UserReadableLabel_Flat;
        public readonly string ColloquialNameLabel_Flat;
        public readonly string UserReadableLabelIncludingColloquialism_Flat;

        public readonly string UserReadableLabel_Sharp;
        public readonly string ColloquialNameLabel_Sharp;
        public readonly string UserReadableLabelIncludingColloquialism_Sharp;

        public readonly string NoteSetLabel_Flat;
        public readonly string NoteSetLabel_Sharp;

        public ScaleEntry(Scale scale)
        {
            ScaleLabel = $"{scale.RootNote}{scale.ModeDefinition.Mode}";
            Scale = scale;
            UserReadableLabel_Flat = GetUserFriendlyLabel(ScaleLabel);
            ColloquialNameLabel_Flat = PentatonicModeHelper.GetScaleColloquialism(scale);
            UserReadableLabelIncludingColloquialism_Flat = !string.IsNullOrWhiteSpace(ColloquialNameLabel_Flat) ? $"{ColloquialNameLabel_Flat} ({UserReadableLabel_Flat})" : $"{UserReadableLabel_Flat}";

            string sharpNote = NoteHelper.ConvertNoteToStringEquivalent(scale.RootNote, true);

            UserReadableLabel_Sharp = GetUserFriendlyLabel($"{sharpNote}{scale.ModeDefinition.Mode}");
            ColloquialNameLabel_Sharp = PentatonicModeHelper.GetScaleColloquialism(scale, true);
            UserReadableLabelIncludingColloquialism_Sharp = !string.IsNullOrWhiteSpace(ColloquialNameLabel_Sharp) ? $"{ColloquialNameLabel_Sharp} ({UserReadableLabel_Sharp})" : $"{UserReadableLabel_Sharp}";

            NoteSetLabel_Flat = string.Join(" ", Scale.NoteSet);
            NoteSetLabel_Sharp = string.Join(" ", Scale.NoteSetSharp);
        }

        /// <summary>
        /// Inserts spaces found where a capital letter is found
        /// </summary>
        /// <param name="label"></param>
        /// <returns>Stringbuilder modified input as a string</returns>
        public static string GetUserFriendlyLabel(string label)
        {
            var sb = new StringBuilder().Append(label);
            int count = 1;

            while (count < sb.Length - 1)
            {
                if (char.IsUpper(sb[count]) && sb[count - 1] != ' ')
                    sb.Insert(count, ' ');

                count++;
            }

            return sb.ToString();
        }

        public bool Equals(ScaleEntry other)
        {
            if (other == null)
            {
                return false;
            }

            return ScaleLabel == other.ScaleLabel;
        }
    }
}