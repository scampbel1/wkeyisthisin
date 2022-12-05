using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyClassLibrary.Models.MusicTheory;
using System.Text;

namespace Keyify.Models.Service
{
    public class ScaleEntry
    {
        public ScaleEntry(GeneratedScale scale)
        {
            Scale = scale;
        }

        private string _sharpRootNote => NoteHelper.ConvertNoteToStringEquivalent(Scale.RootNote, convertFlatNoteToSharp: true);

        public GeneratedScale Scale { get; set; }
        public bool Selected { get; set; }
        public string ScaleLabel => $"{Scale.RootNote}{Scale.ModeDefinition.Mode}";
        public bool IsKey => IsScaleEntryAKey();

        public string NoteSetLabel_Flat => string.Join(" ", Scale.NoteSet);
        public string NoteSetLabel_Sharp => string.Join(" ", Scale.NoteSetSharp);

        public string FormalNameLabel_Flat => GenerateLabel(ScaleLabel);
        public string ColloquialNameLabel_Flat => GenerateScaleColloquialism(Scale, convertFlatNoteToSharp: false);
        public string ColloquialismIncludingFormalName_Flat => !string.IsNullOrWhiteSpace(ColloquialNameLabel_Flat) ? $"{ColloquialNameLabel_Flat} ({FormalNameLabel_Flat})" : $"{FormalNameLabel_Flat}";

        public string FormalNameLabel_Sharp => GenerateLabel($"{_sharpRootNote}{Scale.ModeDefinition.Mode}");
        public string ColloquialNameLabel_Sharp => GenerateScaleColloquialism(Scale, convertFlatNoteToSharp: true);
        public string ColloquialismIncludingFormalName_Sharp => !string.IsNullOrWhiteSpace(ColloquialNameLabel_Sharp) ? $"{ColloquialNameLabel_Sharp} ({FormalNameLabel_Sharp})" : $"{FormalNameLabel_Sharp}";

        private bool IsScaleEntryAKey()
        {
            return Scale.ModeDefinition.Mode == Mode.Ionian || Scale.ModeDefinition.Mode == Mode.Aeolian;
        }

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

        private string GetModeNameColloquialismLabel(Mode mode)
        {
            return GetModeNameColloquialism(mode).ToString();
        }

        private string GenerateScaleColloquialism(GeneratedScale scale, bool convertFlatNoteToSharp)
        {
            var modeEquivalent = GetModeNameColloquialismLabel(scale.ModeDefinition.Mode);

            return !string.IsNullOrWhiteSpace(modeEquivalent) ? $"{NoteHelper.ConvertNoteToStringEquivalent(scale.RootNote, convertFlatNoteToSharp)} {modeEquivalent}" : modeEquivalent;
        }
    }
}