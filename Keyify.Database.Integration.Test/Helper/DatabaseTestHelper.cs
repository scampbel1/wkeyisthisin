using System.Text;
using System.Text.Json;

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

        internal static object CreateInsertStandardTuningSqlScriptParameters()
        {
            using var memoryStream = new MemoryStream();
            var tuningEntry = new[] { 7, 0, 5, 10, 2, 7, };


            JsonSerializer.Serialize(memoryStream, tuningEntry);

            return new
            {
                InstrumentId = 0,
                Name = "Standard Tuning",
                Description = "The tuning your guitar gets delivered with",
                Notes = memoryStream.ToArray()
            };
        }

        internal static string CreateInsertChordSqlScript()
        {
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO[Core].[Chord]");
            sb.AppendLine("([ChordTypeId]");
            sb.AppendLine(",[RootNoteId]");
            sb.AppendLine(",[TuningId]");
            sb.AppendLine(",[Name]");
            sb.AppendLine(",[Tabs]");
            sb.AppendLine(")");
            sb.AppendLine(" VALUES ");
            sb.AppendLine("(");
            sb.AppendLine("@ChordTypeId");
            sb.AppendLine(",@RootNoteId");
            sb.AppendLine(",@TuningId");
            sb.AppendLine(",@Name");
            sb.AppendLine(",@Tabs");
            sb.AppendLine(")");

            return sb.ToString();
        }

        internal static object CreateInsertEMajorChordSqlScriptParameters()
        {
            using var memoryStream = new MemoryStream();
            var eMajorChordTabEntry = new[] { -1, 2, 2, 1, 0, 0, };

            JsonSerializer.Serialize(memoryStream, eMajorChordTabEntry);

            return new
            {
                ChordTypeId = 0,
                RootNoteId = 0,
                TuningId = 0,
                Name = "Test Chord",
                Tabs = memoryStream.ToArray()
            };
        }
    }
}
