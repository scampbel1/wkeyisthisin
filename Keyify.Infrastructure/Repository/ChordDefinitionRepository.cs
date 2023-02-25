using Dapper;
using Keyify.Web.Infrastructure.Models.ChordDefinition;
using Keyify.Web.Infrastructure.Repository.Interfaces;
using System.Data.SqlClient;
using System.Text;

namespace Keyify.Infrastructure.Repository
{
    public class ChordDefinitionRepository : IChordDefinitionRepository
    {
        public Task<List<ChordDefinitionEntity>> GetAllChordDefinitions()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DoesChordDefinitionExist(string name)
        {
            using var sqlConnection = new SqlConnection("Server=.;Database=Keyify;Trusted_Connection=True;");

            await sqlConnection.OpenAsync();

            var query = "SELECT COUNT(1) FROM [Core].[ChordDefinition] WHERE [Name] = @name";
            var isFound = await sqlConnection.ExecuteScalarAsync<bool>(query, new { name });

            await sqlConnection.CloseAsync();

            return isFound;
        }

        public async Task InsertChordDefinition(ChordDefinitionRequest chordDefinitionRequest)
        {
            //TODO: Validate request
            if (await DoesChordDefinitionExist(chordDefinitionRequest.Name))
            {
                return;
            }

            //TODO: Move connection string to somewhere safe - map to environment
            using var sqlCconnection = new SqlConnection("Server=.;Database=Keyify;Trusted_Connection=True;");

            await sqlCconnection.OpenAsync();


            //TODO: Convert to Builder Pattern
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO [Core].[ChordDefinition] (");
            sb.AppendLine("[Name],");
            sb.AppendLine("[Intervals]");
            sb.AppendLine(")");
            sb.AppendLine("VALUES");
            sb.AppendLine("(");
            sb.AppendLine("@Name,");
            sb.AppendLine("@Intervals");
            sb.AppendLine(")");

            var chord = await sqlCconnection.ExecuteAsync(sb.ToString(), new { chordDefinitionRequest.Name, chordDefinitionRequest.Intervals });

            await sqlCconnection.CloseAsync();
        }

        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds)
        {
            throw new NotImplementedException();
        }
    }
}
