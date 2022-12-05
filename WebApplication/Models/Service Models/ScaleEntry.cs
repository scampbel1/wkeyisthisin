using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyClassLibrary.Models.MusicTheory;
using System;
using System.Text;

namespace Keyify.Models.Service
{
    public class ScaleEntry : IEquatable<ScaleEntry>
    {
        public GeneratedScale Scale { get; set; }
        public bool Selected { get; set; }
        public string ScaleLabel { get; set; }
        public bool IsKey => IsScaleEntryAKey();


        public readonly string FormalNameLabel_Flat;
        public readonly string ColloquialNameLabel_Flat;
        public readonly string ColloquialismIncludingFormalName_Flat;

        public readonly string FormalNameLabel_Sharp;
        public readonly string ColloquialNameLabel_Sharp;
        public readonly string ColloquialismIncludingFormalName_Sharp;

        public readonly string NoteSetLabel_Flat;
        public readonly string NoteSetLabel_Sharp;

        public ScaleEntry(GeneratedScale scale)
        {
            ScaleLabel = $"{scale.RootNote}{scale.ModeDefinition.Mode}";
            Scale = scale;
            FormalNameLabel_Flat = GenerateFriendlyLabel(ScaleLabel);
            ColloquialNameLabel_Flat = GetScaleColloquialism(scale);
            ColloquialismIncludingFormalName_Flat = !string.IsNullOrWhiteSpace(ColloquialNameLabel_Flat) ? $"{ColloquialNameLabel_Flat} ({FormalNameLabel_Flat})" : $"{FormalNameLabel_Flat}";

            string sharpNote = NoteHelper.ConvertNoteToStringEquivalent(scale.RootNote, true);

            FormalNameLabel_Sharp = GenerateFriendlyLabel($"{sharpNote}{scale.ModeDefinition.Mode}");
            ColloquialNameLabel_Sharp = GetScaleColloquialism(scale, true);
            ColloquialismIncludingFormalName_Sharp = !string.IsNullOrWhiteSpace(ColloquialNameLabel_Sharp) ? $"{ColloquialNameLabel_Sharp} ({FormalNameLabel_Sharp})" : $"{FormalNameLabel_Sharp}";

            NoteSetLabel_Flat = string.Join(" ", Scale.NoteSet);
            NoteSetLabel_Sharp = string.Join(" ", Scale.NoteSetSharp);
        }
        private bool IsScaleEntryAKey()
        {
            return Scale.ModeDefinition.Mode == Mode.Ionian || Scale.ModeDefinition.Mode == Mode.Aeolian;
        }

        private string GenerateFriendlyLabel(string label)
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

        public bool Equals(ScaleEntry other)
        {
            if (other == null)
            {
                return false;
            }

            return ScaleLabel == other.ScaleLabel;
        }

        private ModeColloquialism? GetModeNameColloquialism(Mode mode)
        {
            switch (mode)
            {
                case Mode.Ionian:
                    return ModeColloquialism.Major;
                case Mode.Aeolian:
                    return ModeColloquialism.Minor;
                default:
                    return null;
            }
        }

        private string GetModeNameColloquialismModeLabel(Mode mode)
        {
            return GetModeNameColloquialism(mode).ToString();
        }

        private string GetScaleColloquialism(GeneratedScale scale, bool convertToSharp = false)
        {
            var pentatonicModeEquivalent = GetModeNameColloquialismModeLabel(scale.ModeDefinition.Mode);

            return !string.IsNullOrWhiteSpace(pentatonicModeEquivalent) ? $"{NoteHelper.ConvertNoteToStringEquivalent(scale.RootNote, convertToSharp)} {pentatonicModeEquivalent}" : pentatonicModeEquivalent;
        }
    }
}