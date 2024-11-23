using Keyify.MusicTheory.Enums;

namespace Keyify.Web.Infrastructure.Models.ChordDefinition
{
    public class ChordDefinitionEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public Interval[]? Intervals { get; set; }

        public int Popularity { get; set; } = 3;
    }
}
