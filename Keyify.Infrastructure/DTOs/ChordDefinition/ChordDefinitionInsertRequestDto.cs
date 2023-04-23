namespace Keyify.Infrastructure.DTOs.ChordDefinition
{
    public class ChordDefinitionInsertRequestDto
    {
        public string? Name { get; set; }
        public int[]? Intervals { get; set; }
    }
}
