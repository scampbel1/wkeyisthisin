namespace Keyify.Infrastructure.Models.Data
{
    public class ScaleDefinitionData
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public byte[] Intervals { get; set; }

        public byte[] Degrees { get; set; }

        public byte[] AllowedRootNotes { get; set; }

        public string? Description { get; set; }
    }
}
