using Keyify.Database.Integration.Test.Enums;
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

            JsonSerializer.Serialize(memoryStream, GuitarTuningConstant.StandardTuning);

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

            JsonSerializer.Serialize(memoryStream, TestGuitarChordTabConstant.StandardTuning_E_Major);

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
