using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questions.Api.Data.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUserGuid = table.Column<Guid>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserGuid = table.Column<Guid>(nullable: true),
                    QuestionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(nullable: false),
                    CompanyGuid = table.Column<Guid>(nullable: false),
                    ProjectGuid = table.Column<Guid>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false),
                    TicketGuid = table.Column<Guid>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
