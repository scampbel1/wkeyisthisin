using Dapper;
using Keyify.Database.Integration.Test.Enums;
using Keyify.Database.Integration.Test.Helper;
using Keyify.Database.Integration.Test.Tests;
using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Keyify.MusicTheory.Enums;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace Keyify.Database.Integration.Tests.Test
{
    public class ChordDatabaseTest : DatabaseIntegrationTest
    {
        public ChordDatabaseTest(ThrowawayDatabaseWrapper throwawayDbInstance) : base(throwawayDbInstance)
        {
        }

        [Fact]
        public async Task CreateChord_RecordCreatedInDatabase_ReturnsSingleRecord_ReturnsCorrectTabsIntArray()
        {
            //Arrange
            await ThrowAwayDatabaseWrapper.ExecuteSqlQueryAsync(DatabaseTestHelper.CreateInsertChordSqlScript(), DatabaseTestHelper.CreateInsertEMajorChordSqlScriptParameters());

            //Act
            var sqlQuery = "SELECT [Tabs] FROM [Core].[Chord]";
            var chord = await ThrowAwayDatabaseWrapper.QuerySingleAsync<byte[]>(sqlQuery);

            var tabResult = await ConvertToIntArray(chord);

            //Assert
            Assert.NotNull(chord);
            Assert.Equal(TestGuitarChordTabConstant.StandardTuning_E_Major, tabResult);

        }

        [Fact]
        public async Task CreateChord_AttemptInsertIntoDatabaseTwice_TriggersUniqueConstraint_ThrowsException() => await Assert.ThrowsAsync<SqlException>(() => ThrowAwayDatabaseWrapper.ExecuteSqlQueryAsync(DatabaseTestHelper.CreateInsertChordSqlScript(), DatabaseTestHelper.CreateInsertEMajorChordSqlScriptParameters()));


        [Fact(Skip = "This is an attempt to figure out how chord definitions are supposed to work")]
        public async Task DeleteMe_GetIntervalBinaryValues()
        {
            //using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            //{

            //}

            var mainArray = new List<Interval[]>()
            {
                new Interval[] { Interval.R, Interval.WW, Interval.Wh },
                new Interval[] { Interval.R, Interval.Wh, Interval.WW },
                new Interval[] { Interval.R, Interval.Wh, Interval.Wh },
                new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW },
                new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh },
                new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh },
                new Interval[] { Interval.R, Interval.W, Interval.WWh },
                new Interval[] { Interval.R, Interval.WWh, Interval.W },
                new Interval[] { Interval.R, Interval.WW, Interval.WW },
                new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh },
                new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW },
                new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW },
                new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.Wh },
                new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh },
                new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW, Interval.Wh },
                new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW },
                new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW },
                new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW },
            };

            var results = new List<byte[]>();

            foreach (var interval in mainArray)
            {
                using var memoryStream = new MemoryStream();

                await JsonSerializer.SerializeAsync(memoryStream, interval);

                results.Add(memoryStream.ToArray());
            }

            Assert.True(results.Count > 0);
        }

        private async Task<int[]?> ConvertToIntArray(byte[] bytes)
        {
            using var memoryStream = new MemoryStream(bytes);

            var ints = await JsonSerializer.DeserializeAsync<int[]>(memoryStream);

            return ints;
        }
    }
}
