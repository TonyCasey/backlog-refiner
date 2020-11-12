using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifications.Data.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUserGuid = table.Column<Guid>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserGuid = table.Column<Guid>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    NotificationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserGuid = table.Column<Guid>(nullable: false),
                    CompanyGuid = table.Column<Guid>(nullable: false),
                    BoardGuid = table.Column<Guid>(nullable: false),
                    TicketGuid = table.Column<Guid>(nullable: true),
                    QuestionGuid = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    ReadDate = table.Column<DateTime>(nullable: true),
                    ClickDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}
