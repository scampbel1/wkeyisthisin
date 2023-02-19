using System.Text;

namespace Keyify.Services.Models
{
    public class ScaleEntry
    {
        public ScaleEntry(GeneratedScale scale)
        {
            Scale = scale;
        }

        public GeneratedScale Scale { get; set; }
        public bool Selected { get; set; }

        //TODO: Move all of this to the GeneratedScale class, it should only be generated once

        public string ScaleLabel => Scale.Label;
        public bool IsKey => Scale.IsKey;

        public string FormalNameLabel_Flat => GenerateLabel(ScaleLabel);
        public string ColloquialNameLabel_Flat => Scale.FlatColloquialism;
        public string ColloquialismIncludingFormalName_Flat => !string.IsNullOrWhiteSpace(ColloquialNameLabel_Flat) ? $"{ColloquialNameLabel_Flat} ({FormalNameLabel_Flat})" : $"{FormalNameLabel_Flat}";

        public string FormalNameLabel_Sharp => GenerateLabel($"{Scale.SharpRootNote}{Scale.Mode}");
        public string ColloquialNameLabel_Sharp => Scale.SharpColloquialism;
        public string ColloquialismIncludingFormalName_Sharp => !string.IsNullOrWhiteSpace(ColloquialNameLabel_Sharp) ? $"{ColloquialNameLabel_Sharp} ({FormalNameLabel_Sharp})" : $"{FormalNameLabel_Sharp}";


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