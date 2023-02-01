using Xunit;

namespace Keyify.Database.Integration.Test
{
    public class ChordDatabaseTest
    {
        //https://khalidabuhakmeh.com/dotnet-database-integration-tests
        //https://github.com/Zaid-Ajaj/ThrowawayDb

        [Fact]
        public async Task Can_Select_Chord_Entry_From_Database()
        {
            using (var throwawayDbInstance = await DatabaseSetup.CreateThrowawayDbInstanceAsync())
            {   
                
            }
        }
    }
}
