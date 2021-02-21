using System.Text.Json;
using Xunit;

namespace Keyify.Unit.Test.Json.UnitTest
{
    public class NoteToJsonConversionUnitTest
    {
        [Fact]
        public void NotesConvertIntoJsonArray()
        {
            var expected = "[\"A\",\"Ab\"]";

            var actual = JsonSerializer.Serialize(new[] { KeyifyClassLibrary.Enums.Note.A.ToString(), KeyifyClassLibrary.Enums.Note.Ab.ToString() });

            Assert.Equal(expected, actual);
        }
    }
}