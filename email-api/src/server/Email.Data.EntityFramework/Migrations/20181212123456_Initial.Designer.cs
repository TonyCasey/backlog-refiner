﻿// <auto-generated />
using System;
using Email.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Email.Data.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181212123456_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Email.Data.Entities.Email", b =>
                {
                    b.Property<long>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("BoardGuid");

                    b.Property<Guid>("CompanyGuid");

                    b.Property<DateTime>("CreationTime");

                    b.Property<Guid>("CreationUserGuid");

                    b.Property<bool?>("Deleted");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime?>("LastUpdateTime");

                    b.Property<Guid?>("LastUpdateUserGuid");

                    b.Property<Guid>("NotificationGuid");

                    b.Property<Guid>("TicketGuid");

                    b.Property<Guid>("ToUserGuid");

                    b.HasKey("EmailId");

                    b.ToTable("Emails");
                });
#pragma warning restore 612, 618
        }
    }
}
