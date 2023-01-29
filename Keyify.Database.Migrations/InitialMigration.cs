using Microsoft.EntityFrameworkCore.Migrations;

namespace Keyify.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("" +
                "CREATE SCHEMA Core" +
                "GO" +
                "" +
                "CREATE TABLE Core.ChordType (" +
                "Id INT," +
                "Name NVARCHAR(100)" +
                ");" +
                "GO");
        }
    }
}