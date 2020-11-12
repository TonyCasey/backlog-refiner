using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tickets.Api.Data.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketMembers",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUserGuid = table.Column<Guid>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserGuid = table.Column<Guid>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    TicketMemberId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyGuid = table.Column<Guid>(nullable: false),
                    TicketGuid = table.Column<Guid>(nullable: false),
                    TeamUserGuid = table.Column<Guid>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketMembers", x => x.TicketMemberId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUserGuid = table.Column<Guid>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserGuid = table.Column<Guid>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    TicketId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyGuid = table.Column<Guid>(nullable: false),
                    BoardGuid = table.Column<Guid>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StatusGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "BoardGuid", "CompanyGuid", "CreationTime", "CreationUserGuid", "Deleted", "Description", "Guid", "LastUpdateTime", "LastUpdateUserGuid", "StatusGuid", "Summary", "UserGuid" },
                values: new object[,]
                {
                    { 1L, new Guid("c131073d-cbd5-4b26-bbda-99eda8392a46"), new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd"), new DateTime(2018, 12, 5, 12, 38, 11, 151, DateTimeKind.Local), new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"), null, @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam venenatis massa eu lorem rutrum scelerisque. Aliquam quis faucibus dui. Morbi eu diam condimentum, aliquet lorem eget, convallis augue. Nam a nisi at est elementum dignissim. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras in magna ac mauris eleifend imperdiet sit amet in purus. Phasellus eu mi arcu. Etiam a tempus lectus. In hac habitasse platea dictumst. Fusce viverra sed metus id pretium. Proin auctor enim eu massa fringilla, at vestibulum lacus egestas.

                In hac habitasse platea dictumst. Phasellus non semper nisi. Proin consequat, ante et pretium imperdiet, velit augue congue leo, consectetur euismod turpis tellus nec felis. Quisque tempor id libero et maximus. In ullamcorper dolor leo, quis tempus sapien auctor id. Sed eget augue vel augue accumsan ornare. Aliquam ac felis a elit bibendum malesuada at eget arcu. Mauris id tempus lacus. Aenean volutpat tristique sem quis interdum. Cras eu eros at lorem tincidunt pharetra vel ac tortor. Donec non suscipit arcu. Maecenas luctus, eros sodales iaculis feugiat, nisl massa venenatis velit, ullamcorper vulputate quam nisi a dui. Aenean posuere, risus quis lobortis dictum, nisi erat mattis odio, eu porttitor massa neque vel ligula. Mauris et pretium justo, id gravida neque.", new Guid("e5a1cd26-a799-4ddf-86ab-0c425a2bd4d4"), null, null, new Guid("0ad8d818-cea5-4401-a851-614f37133ed1"), "Ticket number 1", new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff") },
                    { 2L, new Guid("c131073d-cbd5-4b26-bbda-99eda8392a46"), new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd"), new DateTime(2018, 12, 5, 12, 38, 11, 153, DateTimeKind.Local), new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"), null, @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam venenatis massa eu lorem rutrum scelerisque. Aliquam quis faucibus dui. Morbi eu diam condimentum, aliquet lorem eget, convallis augue. Nam a nisi at est elementum dignissim. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras in magna ac mauris eleifend imperdiet sit amet in purus. Phasellus eu mi arcu. Etiam a tempus lectus. In hac habitasse platea dictumst. Fusce viverra sed metus id pretium. Proin auctor enim eu massa fringilla, at vestibulum lacus egestas.

                In hac habitasse platea dictumst. Phasellus non semper nisi. Proin consequat, ante et pretium imperdiet, velit augue congue leo, consectetur euismod turpis tellus nec felis. Quisque tempor id libero et maximus. In ullamcorper dolor leo, quis tempus sapien auctor id. Sed eget augue vel augue accumsan ornare. Aliquam ac felis a elit bibendum malesuada at eget arcu. Mauris id tempus lacus. Aenean volutpat tristique sem quis interdum. Cras eu eros at lorem tincidunt pharetra vel ac tortor. Donec non suscipit arcu. Maecenas luctus, eros sodales iaculis feugiat, nisl massa venenatis velit, ullamcorper vulputate quam nisi a dui. Aenean posuere, risus quis lobortis dictum, nisi erat mattis odio, eu porttitor massa neque vel ligula. Mauris et pretium justo, id gravida neque.", new Guid("8a81bd0f-5458-4493-b82f-feae8b650a57"), null, null, new Guid("0ad8d818-cea5-4401-a851-614f37133ed1"), "Ticket number 2", new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff") },
                    { 3L, new Guid("48c85d34-1345-4363-93b7-f2d2785bf07e"), new Guid("3272d072-ac00-4d3a-8d3a-40a14d8d789d"), new DateTime(2018, 12, 5, 12, 38, 11, 153, DateTimeKind.Local), new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"), null, @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam venenatis massa eu lorem rutrum scelerisque. Aliquam quis faucibus dui. Morbi eu diam condimentum, aliquet lorem eget, convallis augue. Nam a nisi at est elementum dignissim. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras in magna ac mauris eleifend imperdiet sit amet in purus. Phasellus eu mi arcu. Etiam a tempus lectus. In hac habitasse platea dictumst. Fusce viverra sed metus id pretium. Proin auctor enim eu massa fringilla, at vestibulum lacus egestas.

                In hac habitasse platea dictumst. Phasellus non semper nisi. Proin consequat, ante et pretium imperdiet, velit augue congue leo, consectetur euismod turpis tellus nec felis. Quisque tempor id libero et maximus. In ullamcorper dolor leo, quis tempus sapien auctor id. Sed eget augue vel augue accumsan ornare. Aliquam ac felis a elit bibendum malesuada at eget arcu. Mauris id tempus lacus. Aenean volutpat tristique sem quis interdum. Cras eu eros at lorem tincidunt pharetra vel ac tortor. Donec non suscipit arcu. Maecenas luctus, eros sodales iaculis feugiat, nisl massa venenatis velit, ullamcorper vulputate quam nisi a dui. Aenean posuere, risus quis lobortis dictum, nisi erat mattis odio, eu porttitor massa neque vel ligula. Mauris et pretium justo, id gravida neque.", new Guid("afe42e10-02ce-4c2c-a3e5-81c68ca0f95c"), null, null, new Guid("0ad8d818-cea5-4401-a851-614f37133ed9"), "Ticket number 3", new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff") },
                    { 4L, new Guid("48c85d34-1345-4363-93b7-f2d2785bf07e"), new Guid("3272d072-ac00-4d3a-8d3a-40a14d8d789d"), new DateTime(2018, 12, 5, 12, 38, 11, 153, DateTimeKind.Local), new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"), null, @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam venenatis massa eu lorem rutrum scelerisque. Aliquam quis faucibus dui. Morbi eu diam condimentum, aliquet lorem eget, convallis augue. Nam a nisi at est elementum dignissim. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras in magna ac mauris eleifend imperdiet sit amet in purus. Phasellus eu mi arcu. Etiam a tempus lectus. In hac habitasse platea dictumst. Fusce viverra sed metus id pretium. Proin auctor enim eu massa fringilla, at vestibulum lacus egestas.

                In hac habitasse platea dictumst. Phasellus non semper nisi. Proin consequat, ante et pretium imperdiet, velit augue congue leo, consectetur euismod turpis tellus nec felis. Quisque tempor id libero et maximus. In ullamcorper dolor leo, quis tempus sapien auctor id. Sed eget augue vel augue accumsan ornare. Aliquam ac felis a elit bibendum malesuada at eget arcu. Mauris id tempus lacus. Aenean volutpat tristique sem quis interdum. Cras eu eros at lorem tincidunt pharetra vel ac tortor. Donec non suscipit arcu. Maecenas luctus, eros sodales iaculis feugiat, nisl massa venenatis velit, ullamcorper vulputate quam nisi a dui. Aenean posuere, risus quis lobortis dictum, nisi erat mattis odio, eu porttitor massa neque vel ligula. Mauris et pretium justo, id gravida neque.", new Guid("e22b8d3c-5f9b-4cd8-b419-872924c6c8b0"), null, null, new Guid("0ad8d818-cea5-4401-a851-614f37133ed1"), "Ticket number 4", new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketMembers");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
