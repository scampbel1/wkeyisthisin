using Dapper;
using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Keyify.Enums;
using Keyify.Web.Enums;
using KeyifyClassLibrary.Enums;
using Microsoft.Data.SqlClient;
using Xunit;

namespace Keyify.Database.Integration.Test.Tests
{
    public class LookupTableConsistencyTest
    {        
        private int _noteTypeTableEntryCount;
        private int _chordTypeTableEntryCount;
        private int _instrumentTypeTableEntryCount;

        public LookupTableConsistencyTest()
        {
            Task.Run(SetupFixture).Wait();
        }

        private async Task SetupFixture()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();
                
                //Arrange
                var noteTypeCountSqlQuery = "SELECT COUNT(1) FROM [Core].[Note]";
                var chordTypeCountSqlQuery = "SELECT COUNT(1) FROM [Core].[ChordType]";
                var instrumentTypeCountSqlQuery = "SELECT COUNT(1) FROM [Core].[Instrument]";

                //Act
                _noteTypeTableEntryCount = await sqlCconnection.QuerySingleAsync<int>(noteTypeCountSqlQuery);
                _chordTypeTableEntryCount = await sqlCconnection.QuerySingleAsync<int>(chordTypeCountSqlQuery);
                _instrumentTypeTableEntryCount = await sqlCconnection.QuerySingleAsync<int>(instrumentTypeCountSqlQuery);
            }
        }

        [Fact]
        public void NoteTypeEnum_NoteTypeEntry_CountsAreEqual()
        {
            //Act
            var noteEnumLength = Enum.GetNames(typeof(Note)).Length;

            //Assert
            Assert.Equal(noteEnumLength, _noteTypeTableEntryCount);
        }

        [Fact]
        public void ChordTypeEnum_ChordTypeEntry_CountsAreEqual()
        {
            //Act
            var chordTypeEnumLength = Enum.GetNames(typeof(ChordType)).Length;

            //Assert
            Assert.Equal(chordTypeEnumLength, _chordTypeTableEntryCount);
        }

        [Fact]
        public void InstrumentTypeEnum_InstrumentTypeEntry_CountsAreEqual()
        {
            //Act
            var instrumentTypeEnumLength = Enum.GetNames(typeof(InstrumentType)).Length;

            //Assert
            Assert.Equal(instrumentTypeEnumLength, _instrumentTypeTableEntryCount);
        }
    }
}
