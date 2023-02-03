﻿using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Xunit;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using Keyify.Database.Integration.Test.Helper;
using KeyifyClassLibrary.Enums;
using Dapper;

namespace Keyify.Database.Integration.Tests.Test
{
    public class ChordDatabaseTest
    {
        [Fact]
        public async Task Can_Select_Chord_Entry_From_Database()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                var tuningEntry = new[] { Note.E, Note.A, Note.D, Note.G, Note.B, Note.E, };

                using var memoryStream = new MemoryStream();

                JsonSerializer.Serialize(memoryStream, tuningEntry);

                var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();

                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertTuningSqlScriptParameters(memoryStream));
            }
        }
    }
}