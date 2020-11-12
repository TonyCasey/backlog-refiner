using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boards.Data.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUserGuid = table.Column<Guid>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserGuid = table.Column<Guid>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    BoardId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserGuid = table.Column<Guid>(nullable: false),
                    CompanyGuid = table.Column<Guid>(nullable: false),
                    TeamGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.BoardId);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "CompanyGuid", "CreationTime", "CreationUserGuid", "Deleted", "Guid", "LastUpdateTime", "LastUpdateUserGuid", "Name", "TeamGuid", "UserGuid" },
                values: new object[] { 1L, new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd"), new DateTime(2018, 11, 10, 15, 42, 40, 727, DateTimeKind.Local), new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"), null, new Guid("c131073d-cbd5-4b26-bbda-99eda8392a46"), null, null, "BR Board 1", new Guid("be677a6e-a993-4ae3-9f11-82e4fc3b881f"), new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff") });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "CompanyGuid", "CreationTime", "CreationUserGuid", "Deleted", "Guid", "LastUpdateTime", "LastUpdateUserGuid", "Name", "TeamGuid", "UserGuid" },
                values: new object[] { 2L, new Guid("3272d072-ac00-4d3a-8d3a-40a14d8d789d"), new DateTime(2018, 11, 10, 15, 42, 40, 728, DateTimeKind.Local), new Guid("9922826f-8490-4c04-8f36-07115c6193b5"), null, new Guid("48c85d34-1345-4363-93b7-f2d2785bf07e"), null, null, "Retailer Engineering Board", new Guid("a640ad1f-f981-4fcf-b126-81db36ae3a24"), new Guid("9922826f-8490-4c04-8f36-07115c6193b5") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
