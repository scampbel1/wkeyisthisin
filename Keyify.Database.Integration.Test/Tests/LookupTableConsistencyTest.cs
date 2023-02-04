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
        //Arrange
        private int _noteTypeTableEntryCount;
        private int _chordTypeTableEntryCount;
        private int _instrumentTypeTableEntryCount;

        private int _noteTypeEnumCount = Enum.GetNames(typeof(Note)).Length;
        private int _chordTypeEnumCount = Enum.GetNames(typeof(ChordType)).Length;
        private int _instrumentTypeEnumCount = Enum.GetNames(typeof(InstrumentType)).Length;

        private const string _noteTypeCountSqlQuery = "SELECT COUNT(1) FROM [Core].[Note]";
        private const string _chordTypeCountSqlQuery = "SELECT COUNT(1) FROM [Core].[ChordType]";
        private const string _instrumentTypeCountSqlQuery = "SELECT COUNT(1) FROM [Core].[Instrument]";

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

                //Act
                _noteTypeTableEntryCount = await sqlCconnection.QuerySingleAsync<int>(_noteTypeCountSqlQuery);
                _chordTypeTableEntryCount = await sqlCconnection.QuerySingleAsync<int>(_chordTypeCountSqlQuery);
                _instrumentTypeTableEntryCount = await sqlCconnection.QuerySingleAsync<int>(_instrumentTypeCountSqlQuery);
            }
        }

        [Fact]
        public void NoteTypeEnum_NoteTypeEntry_CountsAreEqual()
        {
            //Assert
            Assert.Equal(_noteTypeEnumCount, _noteTypeTableEntryCount);
        }

        [Fact]
        public void ChordTypeEnum_ChordTypeEntry_CountsAreEqual()
        {
            //Assert
            Assert.Equal(_chordTypeEnumCount, _chordTypeTableEntryCount);
        }

        [Fact]
        public void InstrumentTypeEnum_InstrumentTypeEntry_CountsAreEqual()
        {
            //Assert
            Assert.Equal(_instrumentTypeEnumCount, _instrumentTypeTableEntryCount);
        }
    }
}
