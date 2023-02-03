using System.Text;

namespace Keyify.Database.Integration.Test.Helper
{
    internal static class DatabaseTestHelper
    {
        internal static string FormatSqlScriptForThrowawayDbInstance(string sqlScript)
        {
            sqlScript = sqlScript.Replace("\r\n", " ");
            sqlScript = sqlScript.Replace("GO", "");

            return sqlScript;
        }

        internal static string CreateInsertTuningSqlScript()
        {
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO [Core].[Tuning] (");
            sb.AppendLine(" [InstrumentId]");
            sb.AppendLine(",[Name]");
            sb.AppendLine(",[Description]");
            sb.AppendLine(",[Notes]");
            sb.AppendLine(")");
            sb.AppendLine("VALUES");
            sb.AppendLine("(");
            sb.AppendLine("@InstrumentId");
            sb.AppendLine(",@Name");
            sb.AppendLine(",@Description");
            sb.AppendLine(",@Notes");
            sb.AppendLine(")");

            return sb.ToString();
        }
    }
}
