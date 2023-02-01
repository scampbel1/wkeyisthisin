namespace Keyify.Database.Integration.Test
{
    internal static class DatabaseTestHelper
    {
        internal static string FormatSqlScriptForThrowawayDbInstance(string sqlScript)
        {
            sqlScript = sqlScript.Replace("\r\n", " ");
            sqlScript = sqlScript.Replace("GO", "");

            return sqlScript;
        }
    }
}
