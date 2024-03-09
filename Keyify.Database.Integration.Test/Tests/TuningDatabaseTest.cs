using Keyify.Database.Integration.Test.Enums;
using Keyify.Database.Integration.Test.Helper;
using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Keyify.Infrastructure.Models.Data;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace Keyify.Database.Integration.Test.Tests
{
    public class TuningDatabaseTest : DatabaseIntegrationTest
    {
        //TODO: Research best practices for ThrowawayDb
        // - Use of Snapshots

        public TuningDatabaseTest(ThrowawayDatabaseWrapper throwawayDb) : base (throwawayDb)
        {
        }

        [Fact]
        public async Task CreateTuning_RecordCreatedInDatabase_ReturnsSingleRecord_ReturnsCorrectNotesIntArray()
        {
            await ThrowAwayDatabaseWrapper.ExecuteSqlQueryAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertStandardTuningSqlScriptParameters());

            //Act
            var sqlQuery = "SELECT [Notes] FROM [Core].[Tuning]";
            var tuning = await ThrowAwayDatabaseWrapper.QuerySingleAsync<TuningData>(sqlQuery);

            var notes = await ConvertToIntArray(tuning.Notes);

            //Assert
            Assert.NotNull(tuning);
            Assert.Equal(TestGuitarTuningConstant.StandardTuning, notes);
        }

        [Fact]
        public async Task CreateTuning_AttemptToInsertDuplicateRecords_TriggersUniqueConstraint_ThrowsException() 
            => await Assert.ThrowsAsync<SqlException>(() => ThrowAwayDatabaseWrapper.ExecuteSqlQueryAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertStandardTuningSqlScriptParameters()));


        private async Task<int[]?> ConvertToIntArray(byte[] bytes)
        {
            using var memoryStream = new MemoryStream(bytes);

            var ints = await JsonSerializer.DeserializeAsync<int[]>(memoryStream);

            return ints;
        }
    }
}
