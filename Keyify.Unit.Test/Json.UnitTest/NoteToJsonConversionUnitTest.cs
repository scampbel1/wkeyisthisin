using KeyifyWebClient.Core.Models;
using System.Linq;
using Xunit;

namespace Keyify.Unit.Test.Json.UnitTest
{
    public class NoteToJsonConversionUnitTest
    {
        [Fact]
        public void NotesConvertIntoJsonArray()
        {
            var expected = "[\"A\",\"Ab\"]";
            var model = new InstrumentViewModel();

            model.Notes.FirstOrDefault().Selected = true;
            model.Notes.LastOrDefault().Selected = true;

            var actual = model.SelectedNotesJson;

            Assert.Equal(expected, actual);
        }
    }
}