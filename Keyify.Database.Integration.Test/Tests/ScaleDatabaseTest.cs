using Dapper;
using Keyify.Database.Integration.Test.Helper;
using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Keyify.MusicTheory.Enums;
using System.Data.SqlClient;
using System.Text.Json;

namespace Keyify.Database.Integration.Test.Tests
{
    public class ScaleDatabaseTest
    {
        [Fact]
        public async Task CreateScale_WithDefinedRootNotes_ReturnsChordDefinition_WithDefinedNotes()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                var expectedAllowedNotes = new[] { Note.D, Note.F };

                using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();

                //Arrange
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertScaleDefinitionSqlScript_DefinedRootNotes(), DatabaseTestHelper.CreateInsertChordDefinitionSqlScriptParameters_DefinedRootNotes());

                //Act
                var sqlQuery = "SELECT [Name], [Description], [Intervals], [Degrees], [AllowedRootNotes] FROM [Core].[ScaleDefinition]";
                var scaleDefinition = await sqlCconnection.QuerySingleAsync(sqlQuery);

                using var memoryStream = new MemoryStream(scaleDefinition.AllowedRootNotes);
                var allowedRootNotesResult = await JsonSerializer.DeserializeAsync<Note[]>(memoryStream);

                await sqlCconnection.CloseAsync();

                //Assert
                Assert.NotNull(allowedRootNotesResult);
                Assert.Single(allowedRootNotesResult);
                Assert.Equal(expectedAllowedNotes, allowedRootNotesResult);
            }
        }
    }
}
