using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projects.Api.Data.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUserGuid = table.Column<Guid>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserGuid = table.Column<Guid>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    ProjectId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CompanyGuid = table.Column<Guid>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false),
                    TeamGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
