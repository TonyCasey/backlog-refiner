﻿// <auto-generated />
using System;
using Comments.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Comments.Data.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181101093327_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Comments.Data.Entities.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<Guid>("CompanyGuid");

                    b.Property<DateTime>("CreationTime");

                    b.Property<Guid>("CreationUserGuid");

                    b.Property<bool>("Deleted");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime?>("LastUpdateTime");

                    b.Property<Guid?>("LastUpdateUserGuid");

                    b.Property<Guid>("TicketGuid");

                    b.Property<Guid>("UserGuid");

                    b.HasKey("CommentId");

                    b.ToTable("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
