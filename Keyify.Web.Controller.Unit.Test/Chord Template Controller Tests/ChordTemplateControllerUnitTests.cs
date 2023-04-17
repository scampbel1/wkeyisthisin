using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Keyify.Web.Controllers.Music_Theory;
using NuGet.Protocol;
using System.Text.Json;

namespace Keyify.Web.Controller.Unit.Test.Chord_Template_Controller_Tests
{
    public class ChordTemplateControllerUnitTests
    {
        private readonly ChordDefinitionController _chordTemplateController;
        private readonly Mock<IChordDefinitionService> m_chordDefinitionService;

        //Arrange
        private const string _chordDefinitionName = "testChordTemplate";
        private const string _chordDefintionIntervals = "WW-W-h";

        private readonly ChordDefinitionCheckRequest _chordDefinitionCheckRequest;

        public ChordTemplateControllerUnitTests()
        {
            m_chordDefinitionService = new Mock<IChordDefinitionService>();

            _chordTemplateController = new ChordDefinitionController(m_chordDefinitionService.Object);
            _chordDefinitionCheckRequest = new ChordDefinitionCheckRequest() { Name = _chordDefinitionName, Intervals = _chordDefintionIntervals };

        }

        [Fact]
        public async Task ChordTemplateController_Submit_WasInserted_ReturnsTrue()
        {
            //Arrange
            m_chordDefinitionService.Setup(m => m.InsertChordDefinition(It.IsAny<string>(), It.IsAny<Interval[]>())).ReturnsAsync(true);

            //Act
            var result = await _chordTemplateController.Submit(_chordDefinitionCheckRequest);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordTemplateCheckResponse>(json);

            //Assert
            Assert.True(responseModel?.WasInserted);

            m_chordDefinitionService.Reset();
        }
        
        [Fact]
        public async Task ChordTemplateController_Submit_WasNotInserted_ReturnsFalse()
        {
            //Arrange
            m_chordDefinitionService.Setup(m => m.InsertChordDefinition(It.IsAny<string>(), It.IsAny<Interval[]>())).ReturnsAsync(false);

            //Act
            var result = await _chordTemplateController.Submit(_chordDefinitionCheckRequest);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordTemplateCheckResponse>(json);

            //Assert
            Assert.False(responseModel?.WasInserted);

            m_chordDefinitionService.Reset();
        }

        [Fact]
        public async Task ChordTemplateController_Submit_WasInserted_ReturnsSameName()
        {
            //Arrange            
            m_chordDefinitionService.Setup(m => m.InsertChordDefinition(It.IsAny<string>(), It.IsAny<Interval[]>())).ReturnsAsync(false);

            //Act
            var result = await _chordTemplateController.Submit(_chordDefinitionCheckRequest);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordTemplateCheckResponse>(json);

            //Assert            
            Assert.NotNull(responseModel?.Name);
            Assert.NotEmpty(responseModel?.Name.ToCharArray()!);
            
            m_chordDefinitionService.Reset();
        }

        [Fact]
        public async Task ChordTemplateController_Submit_WasInserted_ReturnsParsedNoteArray()
        {
            //Arrange
            var expectedIntervals = new[] { Interval.WW, Interval.W, Interval.h };
            m_chordDefinitionService.Setup(m => m.InsertChordDefinition(It.IsAny<string>(), It.IsAny<Interval[]>())).ReturnsAsync(false);

            //Act
            var result = await _chordTemplateController.Submit(_chordDefinitionCheckRequest);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordTemplateCheckResponse>(json);

            //Assert            
            Assert.NotNull(responseModel?.Intervals);
            Assert.Equal(expectedIntervals, responseModel?.Intervals);
            
            m_chordDefinitionService.Reset();
        }
    }

    //TODO: Rename and move to appropriate location
    public class ChordTemplateCheckResponse
    {
        public string? Name { get; set; }
        public bool? WasInserted { get; set; }
        public Interval[]? Intervals { get; set; }
    }
}
