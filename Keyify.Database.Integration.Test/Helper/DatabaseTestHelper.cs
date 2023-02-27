using EnumsNET;
using Keyify.Database.Integration.Test.Enums;
using Keyify.MusicTheory.Enums;
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

        internal static string CreateInsertScaleDefinitionSqlScript_DefinedRootNotes()
        {
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO [Core].[ScaleDefinition]");
            sb.AppendLine("(");
            sb.AppendLine("[Name],");
            sb.AppendLine("[Description],");
            sb.AppendLine("[Intervals],");
            sb.AppendLine("[Degrees],");
            sb.AppendLine("[AllowedRootNotes]");
            sb.AppendLine(")");
            sb.AppendLine("VALUES");
            sb.AppendLine("(");
            sb.AppendLine("@Name,");
            sb.AppendLine("@Description,");
            sb.AppendLine("@Intervals,");
            sb.AppendLine("@Degrees,");
            sb.AppendLine("@AllowedRootNotes");
            sb.AppendLine(")");

            return sb.ToString();
        }
        internal static object CreateInsertChordDefinitionSqlScriptParameters_DefinedRootNotes()
        {
            var mode = Mode.WholeTone;
            var intervals = new Interval[] { Interval.R, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W, Interval.W };
            var degrees = new string[] { Degree.First, Degree.Second, Degree.Third, Degree.SharpFourth, Degree.SharpFifth, Degree.FlatSeventh, Degree.Eighth };
            var allowedRootNotes = new[] { Note.D, Note.F };

            using var intervalsMemoryStream = new MemoryStream();
            JsonSerializer.Serialize(intervalsMemoryStream, intervals);

            using var degreesMemoryStream = new MemoryStream();
            JsonSerializer.Serialize(degreesMemoryStream, degrees);

            using var allowedRootNotesMemoryStream = new MemoryStream();
            JsonSerializer.Serialize(allowedRootNotesMemoryStream, allowedRootNotes);

            return new
            {
                Name = mode.AsString(EnumFormat.Description),
                Description = "This is just a test",
                Intervals = intervalsMemoryStream.ToArray(),
                Degrees = degreesMemoryStream.ToArray(),
                AllowedRootNotes = allowedRootNotesMemoryStream.ToArray()
            };
        }

        internal static string CreateInsertChordDefinitionSqlScript()
        {
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

            return sb.ToString();
        }

        internal static object CreateInsertChordDefinitionSqlScriptParameters()
        {
            using var memoryStream = new MemoryStream();

            JsonSerializer.Serialize(memoryStream, TestChordDefinitionConstant.Major);

            return new
            {
                Name = ChordType.Major.AsString(EnumFormat.Description),
                Intervals = memoryStream.ToArray()
            };
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

            JsonSerializer.Serialize(memoryStream, TestGuitarTuningConstant.StandardTuning);

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

            sb.AppendLine("INSERT INTO [Core].[Chord](");
            sb.AppendLine(" [ChordTypeId]");
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
