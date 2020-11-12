using Microsoft.EntityFrameworkCore.Migrations;

namespace Email.Data.EntityFramework.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SendGridId",
                table: "Emails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendGridId",
                table: "Emails");
        }
    }
}
