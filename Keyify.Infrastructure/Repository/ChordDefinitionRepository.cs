using Dapper.Contrib.Extensions;
using Keyify.Web.Infrastructure.Models.ChordDefinition;
using Keyify.Web.Infrastructure.Repository.Interfaces;
using System.Data.SqlClient;

namespace Keyify.Infrastructure.Repository
{
    public class ChordDefinitionRepository : IChordDefinitionRepository
    {
        public Task<List<ChordDefinitionEntity>> GetAllChordDefinitions()
        {
            throw new NotImplementedException();
        }

        public Task<ChordDefinitionEntity> GetChordDefinition(ChordDefinitionRequest chordDefinitionRequest)
        {
            throw new NotImplementedException();
        }

        public async Task InsertChordDefinition(ChordDefinitionRequest chordDefinitionRequest)
        {
            using var sqlCconnection = new SqlConnection("Server=.;Database=Keyify;Trusted_Connection=True;");
            
            await sqlCconnection.OpenAsync();

            var chord = await sqlCconnection.InsertAsync(chordDefinitionRequest);

            await sqlCconnection.CloseAsync();
        }

        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds)
        {
            throw new NotImplementedException();
        }
    }
}
