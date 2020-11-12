﻿// <auto-generated />
using System;
using Boards.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Boards.Data.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Boards.Data.Entities.Board", b =>
                {
                    b.Property<long>("BoardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CompanyGuid");

                    b.Property<DateTime>("CreationTime");

                    b.Property<Guid>("CreationUserGuid");

                    b.Property<bool?>("Deleted");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime?>("LastUpdateTime");

                    b.Property<Guid?>("LastUpdateUserGuid");

                    b.Property<string>("Name");

                    b.Property<Guid>("TeamGuid");

                    b.Property<Guid>("UserGuid");

                    b.HasKey("BoardId");

                    b.ToTable("Boards");

                    b.HasData(
                        new { BoardId = 1L, CompanyGuid = new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd"), CreationTime = new DateTime(2018, 11, 10, 15, 42, 40, 727, DateTimeKind.Local), CreationUserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"), Guid = new Guid("c131073d-cbd5-4b26-bbda-99eda8392a46"), Name = "BR Board 1", TeamGuid = new Guid("be677a6e-a993-4ae3-9f11-82e4fc3b881f"), UserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff") },
                        new { BoardId = 2L, CompanyGuid = new Guid("3272d072-ac00-4d3a-8d3a-40a14d8d789d"), CreationTime = new DateTime(2018, 11, 10, 15, 42, 40, 728, DateTimeKind.Local), CreationUserGuid = new Guid("9922826f-8490-4c04-8f36-07115c6193b5"), Guid = new Guid("48c85d34-1345-4363-93b7-f2d2785bf07e"), Name = "Retailer Engineering Board", TeamGuid = new Guid("a640ad1f-f981-4fcf-b126-81db36ae3a24"), UserGuid = new Guid("9922826f-8490-4c04-8f36-07115c6193b5") }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
