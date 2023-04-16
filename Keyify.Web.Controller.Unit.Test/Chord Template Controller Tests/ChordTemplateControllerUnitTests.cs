using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.MusicTheory.Enums;
using Keyify.Web.Controllers.Music_Theory;
using NuGet.Protocol;
using System.Text.Json;

namespace Keyify.Web.Controller.Unit.Test.Chord_Template_Controller_Tests
{
    public class ChordTemplateControllerUnitTests
    {
        private ChordDefinitionController _chordTemplateController;

        //Arrange
        private const string _chordDefinitionName = "testChordTemplate";
        private const string _chordDefintionIntervals = "WW-W-h";

        private readonly ChordDefinitionCheckRequest _chordDefinitionCheckRequest;

        public ChordTemplateControllerUnitTests()
        {
            _chordTemplateController = new ChordDefinitionController();
            _chordDefinitionCheckRequest = new ChordDefinitionCheckRequest() { Name = _chordDefinitionName, Intervals = _chordDefintionIntervals };
        }

        [Fact]
        public void ChordTemplateController_CheckChordTemplateExists_Exists_ReturnsTrue()
        {
            //Arrange

            //Act
            var result = _chordTemplateController.Find(_chordDefinitionCheckRequest);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordTemplateCheckResponse>(json);

            //Assert
            Assert.True(responseModel?.Found);
        }

        [Fact]
        public void ChordTemplateController_CheckChordTemplateExists_Exists_ReturnsSameName()
        {
            //Arrange            

            //Act
            var result = _chordTemplateController.Find(_chordDefinitionCheckRequest);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordTemplateCheckResponse>(json);

            //Assert            
            Assert.NotNull(responseModel?.Name);
            Assert.NotEmpty(responseModel?.Name.ToCharArray()!);
        }

        [Fact]
        public void ChordTemplateController_CheckChordTemplateExists_Exists_ReturnsParsedNoteArray()
        {
            //Arrange
            var expectedIntervals = new[] { Interval.WW, Interval.W, Interval.h };

            //Act
            var result = _chordTemplateController.Find(_chordDefinitionCheckRequest);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordTemplateCheckResponse>(json);

            //Assert            
            Assert.NotNull(responseModel?.Intervals);
            Assert.Equal(expectedIntervals, responseModel?.Intervals);
        }
    }

    //TODO: Rename and move to appropriate location
    public class ChordTemplateCheckResponse
    {
        public string? Name { get; set; }
        public bool? Found { get; set; }
        public Interval[]? Intervals { get; set; }
    }
}
