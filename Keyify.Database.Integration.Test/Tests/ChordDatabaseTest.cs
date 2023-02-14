using Dapper;
using Keyify.Database.Integration.Test.Enums;
using Keyify.Database.Integration.Test.Helper;
using Keyify.Database.Integration.Test.ThrowawayDatabases;
using KeyifyClassLibrary.Enums;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using Xunit;

namespace Keyify.Database.Integration.Tests.Test
{
    public class ChordDatabaseTest
    {
        [Fact]
        public async Task CreateChord_RecordCreatedInDatabase_ReturnsSingleRecord_ReturnsCorrectTabsIntArray()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();

                //Arrange
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordDefinitionSqlScript(), DatabaseTestHelper.CreateInsertChordTemplateSqlScriptParameters());
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertStandardTuningSqlScriptParameters());
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordSqlScript(), DatabaseTestHelper.CreateInsertEMajorChordSqlScriptParameters());

                //Act
                var sqlQuery = "SELECT [Tabs] FROM [Core].[Chord]";
                var chord = await sqlCconnection.QuerySingleAsync(sqlQuery);

                using var memoryStream = new MemoryStream(chord.Tabs);
                var tabResult = await JsonSerializer.DeserializeAsync<int[]>(memoryStream);

                await sqlCconnection.CloseAsync();

                //Assert
                Assert.Single(chord);
                Assert.Equal(TestGuitarChordTabConstant.StandardTuning_E_Major, tabResult);
            }
        }

        [Fact]
        public async Task CreateChord_AttemptInsertIntoDatabaseTwice_TriggersUniqueConstraint_ThrowsException()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();

                //Arrange
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordDefinitionSqlScript(), DatabaseTestHelper.CreateInsertChordTemplateSqlScriptParameters());
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertStandardTuningSqlScriptParameters());
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordSqlScript(), DatabaseTestHelper.CreateInsertEMajorChordSqlScriptParameters());

                //Act
                Func<Task> duplicateRecordInsertAttempt = () => sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordSqlScript(), DatabaseTestHelper.CreateInsertEMajorChordSqlScriptParameters());

                //Assert
                await Assert.ThrowsAsync<SqlException>(duplicateRecordInsertAttempt);
            }
        }

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

            var results = new List<Byte[]>();

            foreach (var interval in mainArray)
            {
                using var memoryStream = new MemoryStream();

                await JsonSerializer.SerializeAsync(memoryStream, interval);

                results.Add(memoryStream.ToArray());
            }

            Assert.True(results.Count > 0);
        }
    }
}
