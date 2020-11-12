using Microsoft.EntityFrameworkCore.Migrations;

namespace Bdd.Data.EntityFramework.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectGuid",
                table: "Scenarios",
                newName: "BoardGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BoardGuid",
                table: "Scenarios",
                newName: "ProjectGuid");
        }
    }
}
