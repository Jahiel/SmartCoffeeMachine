﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartCoffeeMachine.Core.CoffeeMachine.Class;

#nullable disable

namespace SmartCoffeeMachine.Migrations
{
    [DbContext(typeof(CoffeeMachineDbContext))]
    partial class CoffeeMachineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartCoffeeMachine.Core.CoffeeMachine.Class.CoffeeMachineLogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DayOfWeekNumber")
                        .HasColumnType("int");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HourSlot")
                        .HasColumnType("int");

                    b.Property<DateOnly>("LogDate")
                        .HasColumnType("date");

                    b.Property<string>("ParametersJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Action", "DayOfWeekNumber", "LogDate", "HourSlot");

                    b.ToTable("Logs");
                });
#pragma warning restore 612, 618
        }
    }
}
