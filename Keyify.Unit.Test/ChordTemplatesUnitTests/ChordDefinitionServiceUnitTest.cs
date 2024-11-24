using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Service;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using Keyify.Web.Unit.Test.ChordTemplates.UnitTests.Data;
using Keyify.Web.Unit.Test.ChordTemplates.UnitTests.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keyify.Web.Unit.Test.ChordTemplatesUnitTests;

public class ChordDefinitionServiceUnitTest
{
    private static readonly IChordDefinitionCache _dataCache = new MockChordDefinitionCache();
    private static readonly IChordDefinitionRepository _repository = new MockChordDefinitionRepository();
    private static readonly ChordDefinitionService _chordDefinitionService = new(_dataCache, _repository);

    public static IEnumerable<object[]> ChordTestParameters => TestArguments.ChordTemplateParams;

    [Theory, MemberData(nameof(ChordTestParameters))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1042:The member referenced by the MemberData attribute returns untyped data rows", Justification = "Unit Test")]
    public async Task PassNoteSequenceIntoChordService_ReturnsExpectedChord(Note[] selectedChordNotes, ChordDefinition expectedChordDefinition)
    {
        //Arrange - Given
        var inputNotes = selectedChordNotes;

        //Act - When
        var chordDefinitions = await _chordDefinitionService.FindChordDefinitions(inputNotes);
        var result = chordDefinitions.SingleOrDefault(c => c == expectedChordDefinition);

        //Assert - Then
        Assert.Equal(expectedChordDefinition, result);
        Assert.Equal(expectedChordDefinition.Type, result.Type);
    }

    [Fact]
    public async Task SearchChord_A_Major_Notes_ReturnsChordWithinSet()
    {
        //Arrange - Given
        var expectedChordName = "A Major";
        var inputNotes = new[] { Note.A, Note.Db, Note.E };

        //Act - When
        var chordDefinitions = await _chordDefinitionService.FindChordDefinitions(inputNotes);

        var result = chordDefinitions.SingleOrDefault(c => c.Name == expectedChordName);

        //Assert - Then
        Assert.NotNull(result);
        Assert.Equal(expectedChordName, result.Name);
    }

    [Fact]
    public async Task SearchChord_Gb_Minor_Notes_ReturnsChordWithinSet()
    {
        var dataCache = new MockChordDefinitionCache();
        var repository = new MockChordDefinitionRepository();
        var chordDefinitionService = new ChordDefinitionService(dataCache, repository);

        //Arrange - Given
        var expectedChordName = "Gb Minor";
        var inputNotes = new[] { Note.Gb, Note.A, Note.Db };

        //Act - When
        var chordDefinitions = await chordDefinitionService.FindChordDefinitions(inputNotes);

        var result = chordDefinitions.SingleOrDefault(c => c.Name == expectedChordName);

        //Assert - Then
        Assert.NotNull(result);
        Assert.Equal(expectedChordName, result.Name);
    }

    [Fact]
    public void Chord_SameNotes_SameChordType_DifferentSequence_AreNotStrictEqual()
    {
        //Arrange - Given
        var chord1 = new ChordDefinition(ChordType.Major.ToString(), [Note.F, Note.A, Note.C]);

        //Act - When
        var chord2 = new ChordDefinition(ChordType.Major.ToString(), [Note.C, Note.A, Note.F]);

        //Assert - Then
        Assert.NotStrictEqual(chord1, chord2);
    }

    //TODO: Test for Flat to Sharp name conversion

    [Fact]
    public void Chord_SameNotes_SameChordType_DifferentSequence_AreNotEqual()
    {
        //Arrange - Given
        var chord1 = new ChordDefinition(ChordType.Major.ToString(), [Note.F, Note.A, Note.C]);

        //Act - When
        var chord2 = new ChordDefinition(ChordType.Major.ToString(), [Note.C, Note.A, Note.F]);

        //Assert - Then
        Assert.NotEqual(chord1, chord2);
    }
}