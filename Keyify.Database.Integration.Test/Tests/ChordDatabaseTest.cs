using Keyify.Database.Integration.Test.Helper;
using Xunit;

namespace Keyify.Database.Integration.Tests.Test
{
    public class ChordDatabaseTest
    {
        [Fact]
        public async Task Can_Select_Chord_Entry_From_Database()
        {
            using (var throwawayDbInstance = await DatabaseSetup.CreateThrowawayDbInstanceAsync())
            {

            }
        }
    }
}
