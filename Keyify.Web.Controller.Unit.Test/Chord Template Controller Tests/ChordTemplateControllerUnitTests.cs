using Keyify.Web.Controllers.Music_Theory;
using NuGet.Protocol;
using System.Text.Json;

namespace Keyify.Web.Controller.Unit.Test.Chord_Template_Controller_Tests
{
    public class ChordTemplateControllerUnitTests
    {
        private ChordTemplateController _chordTemplateController;

        public ChordTemplateControllerUnitTests()
        {
            _chordTemplateController = new ChordTemplateController();
        }

        [Fact]
        public void ChordTemplateController_CheckChordTemplateExists_Exists_ReturnsTrue()
        {
            //Arrange
            const string chordTemplate = "testChordTemplate";

            //Act
            var result = _chordTemplateController.Find(chordTemplate);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordTemplateCheckResponse>(json);

            //Assert
            Assert.True(responseModel?.Found);            
        }
        
        [Fact]
        public void ChordTemplateController_CheckChordTemplateExists_Exists_ReturnsSameName()
        {
            //Arrange
            const string chordTemplate = "testChordTemplate";

            //Act
            var result = _chordTemplateController.Find(chordTemplate);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordTemplateCheckResponse>(json);

            //Assert            
            Assert.Equal(chordTemplate, responseModel?.Name);
        }
    }

    //TODO: Rename and move to appropriate location
    public class ChordTemplateCheckResponse
    {
        public string? Name { get; set; }
        public bool? Found { get; set; }
    }
}
