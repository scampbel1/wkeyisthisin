using Dapper;
using Keyify.Database.Integration.Test.Helper;
using Keyify.Database.Integration.Test.Models;
using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Keyify.Infrastructure.Models.Data;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using System.Data.SqlClient;
using System.Text.Json;

namespace Keyify.Database.Integration.Test.Tests
{

    public class ScaleDatabaseTest : DatabaseIntegrationTest
    {

        private const string expectedChordTemplateDescription = "This is just a test";

        public ScaleDatabaseTest(ThrowawayDatabaseWrapper throwawayDb) : base(throwawayDb)
        {

        }

        [Fact]
        public async Task CreateScale_WithDefinedRootNotes_ReturnsChordDefinition_WithDefinedNotes_ExpectedNotesReturned()
        {

            const string expectedChordTemplateName = "Whole Tone";

            var expectedAllowedNotes = new[] { Note.D, Note.F };

            //Arrange
            await ThrowAwayDatabaseWrapper.ExecuteSqlQueryAsync(DatabaseTestHelper.CreateInsertScaleDefinitionSqlScript_DefinedRootNotes(), DatabaseTestHelper.CreateInsertChordDefinitionSqlScriptParameters_DefinedRootNotes());

            //Act
            var sqlQuery = "SELECT [Name], [Intervals], [Degrees], [Description], [AllowedRootNotes] FROM [Core].[ScaleDefinition]";
            var scaleDefinition = await ThrowAwayDatabaseWrapper.QuerySingleAsync<ScaleDefinitionData>(sqlQuery);

            // TODO: Create factory with all this conversion stuff - use ...Data types and remove ...Entity types
            var rootNotes = await ConvertToNoteArray(scaleDefinition!.AllowedRootNotes);

            //TODO: Tests aren't isolated - create script to delete record

            //Assert
            Assert.NotNull(scaleDefinition?.AllowedRootNotes);
            Assert.Equal(expectedAllowedNotes, rootNotes);
            Assert.Equal(expectedChordTemplateName, scaleDefinition?.Name);
            Assert.Equal(expectedChordTemplateDescription, scaleDefinition?.Description);
        }

        [Fact]
        public async Task CreateScale_WithoutDefinedRootNotes_ReturnsChordDefinition_NoDefinedNotes_NullDefinedNotesArray()
        {
            const string expectedChordTemplateName = "Blues";

            //Arrange
            await ThrowAwayDatabaseWrapper.ExecuteSqlQueryAsync(DatabaseTestHelper.CreateInsertScaleDefinitionSqlScript_NoRootNotes(), DatabaseTestHelper.CreateInsertChordDefinitionSqlScriptParameters_NoRootNotes());

            //Act
            var sqlQuery = $"SELECT [Name], [Description], [Intervals], [Degrees], [AllowedRootNotes] FROM [Core].[ScaleDefinition] WHERE [Name] = '{expectedChordTemplateName}'";
            var scaleDefinition = await ThrowAwayDatabaseWrapper.QuerySingleAsync<ScaleDefinitionData>(sqlQuery);

            //Assert
            Assert.NotNull(scaleDefinition);
            Assert.Null(scaleDefinition.AllowedRootNotes);
            Assert.Equal(expectedChordTemplateName, scaleDefinition.Name);
            Assert.Equal(expectedChordTemplateDescription, scaleDefinition.Description);
        }

        private async Task<Note[]?> ConvertToNoteArray(byte[] bytes)
        {
            using var memoryStream = new MemoryStream(bytes);

            var intervals = await JsonSerializer.DeserializeAsync<Note[]>(memoryStream);

            return intervals;
        }
    }
}
