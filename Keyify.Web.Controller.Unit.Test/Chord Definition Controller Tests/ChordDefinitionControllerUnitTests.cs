using AutoMapper;
using Keyify.Infrastructure.DTOs.ChordDefinition;
using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.Service.Interfaces;
using Keyify.Web.Controllers.Music_Theory;
using Keyify.Web.Mapping;
using NuGet.Protocol;
using System.Text.Json;

namespace Keyify.Web.Controller.Unit.Test.Chord_Definition_Controller_Tests
{
    public class ChordDefinitionControllerUnitTests
    {
        private readonly Mapper _mapper = new Mapper(new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        }));

        private readonly ChordDefinitionController _chordTemplateController;
        private readonly Mock<IChordDefinitionService> m_chordDefinitionService;

        private const string _chordDefinitionName = "testChordTemplate";
        private int[] _chordDefintionIntervals = new[] { 4, 2, 1 };

        private readonly ChordDefinitionInsertRequestDto _chordDefinitionCheckRequest;

        public ChordDefinitionControllerUnitTests()
        {
            m_chordDefinitionService = new Mock<IChordDefinitionService>();

            _chordTemplateController = new ChordDefinitionController(_mapper, m_chordDefinitionService.Object);
            _chordDefinitionCheckRequest = new ChordDefinitionInsertRequestDto() { Name = _chordDefinitionName, Intervals = _chordDefintionIntervals };
        }

        [Fact]
        public async Task ChordTemplateController_Submit_WasInserted_ReturnsTrue()
        {
            //Arrange
            m_chordDefinitionService.Setup(m => m.InsertChordDefinition(It.IsAny<ChordDefinitionInsertRequest>())).ReturnsAsync(Tuple.Create(true, It.IsAny<string>()));

            //Act
            var result = await _chordTemplateController.Submit(_chordDefinitionCheckRequest);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordDefinitionCheckTestResponse>(json);

            //Assert
            Assert.True(responseModel?.WasInserted);

            m_chordDefinitionService.Reset();
        }

        [Fact]
        public async Task ChordTemplateController_Submit_WasNotInserted_ReturnsFalse()
        {
            //Arrange
            m_chordDefinitionService.Setup(m => m.InsertChordDefinition(It.IsAny<ChordDefinitionInsertRequest>())).ReturnsAsync(Tuple.Create(false, It.IsAny<string>()));

            //Act
            var result = await _chordTemplateController.Submit(_chordDefinitionCheckRequest);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordDefinitionCheckTestResponse>(json);

            //Assert
            Assert.False(responseModel?.WasInserted);

            m_chordDefinitionService.Reset();
        }

        [Fact]
        public async Task ChordTemplateController_Submit_WasInserted_ReturnsSameName()
        {
            //Arrange            
            m_chordDefinitionService.Setup(m => m.InsertChordDefinition(It.IsAny<ChordDefinitionInsertRequest>())).ReturnsAsync(Tuple.Create(false, It.IsAny<string>()));

            //Act
            var result = await _chordTemplateController.Submit(_chordDefinitionCheckRequest);
            var json = result.Value.ToJson();
            var responseModel = JsonSerializer.Deserialize<ChordDefinitionCheckTestResponse>(json);

            //Assert            
            Assert.NotNull(responseModel?.Name);
            Assert.NotEmpty(responseModel?.Name.ToCharArray()!);

            m_chordDefinitionService.Reset();
        }
    }
}
