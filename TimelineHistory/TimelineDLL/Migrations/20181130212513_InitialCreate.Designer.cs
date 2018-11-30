﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimelineDLL.Models;

namespace TimelineDLL.Migrations
{
    [DbContext(typeof(HistoryContext))]
    [Migration("20181130212513_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimelineDLL.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int?>("Event");

                    b.Property<byte[]>("ImageContent");

                    b.Property<bool>("IsKeyEvent");

                    b.Property<int?>("Persona");

                    b.Property<int>("TimePeriodId");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("TimePeriodId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("TimelineDLL.Models.TimePeriod", b =>
                {
                    b.Property<int>("TimePeriodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("TimePeriodId");

                    b.ToTable("TimePeriods");
                });

            modelBuilder.Entity("TimelineDLL.Models.Post", b =>
                {
                    b.HasOne("TimelineDLL.Models.TimePeriod", "TimePeriod")
                        .WithMany("Posts")
                        .HasForeignKey("TimePeriodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
