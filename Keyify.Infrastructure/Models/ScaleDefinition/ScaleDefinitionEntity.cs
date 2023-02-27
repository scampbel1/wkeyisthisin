using Keyify.MusicTheory.Enums;

namespace Keyify.Infrastructure.Models.ScaleDefinition
{
    public class ScaleDefinitionEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Interval[]? Intervals { get; set; }
        public string[]? Degrees { get; set; }
        public Array? AllowedRootNotes { get; set; }
    }
}
