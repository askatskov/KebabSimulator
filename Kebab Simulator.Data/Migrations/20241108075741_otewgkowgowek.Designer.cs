﻿// <auto-generated />
using System;
using Kebab_Simulator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kebab_Simulator.Data.Migrations
{
    [DbContext(typeof(KebabSimulatorContext))]
    [Migration("20241108075741_otewgkowgowek")]
    partial class otewgkowgowek
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kebab_Simulator.Core.Domain.Dto.FileToDatabase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("KebabID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("FilesToDatabase");
                });

            modelBuilder.Entity("Kebab_Simulator.Core.Domain.Kebab", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Checkout")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("KebabBankAccount")
                        .HasColumnType("int");

                    b.Property<DateTime>("KebabDone")
                        .HasColumnType("datetime2");

                    b.Property<int>("KebabFoods")
                        .HasColumnType("int");

                    b.Property<int>("KebabLevel")
                        .HasColumnType("int");

                    b.Property<string>("KebabName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KebabStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("KebabStatus")
                        .HasColumnType("int");

                    b.Property<int>("KebabType")
                        .HasColumnType("int");

                    b.Property<int>("KebabXP")
                        .HasColumnType("int");

                    b.Property<int>("KebabXPNextLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Kebabs");
                });
#pragma warning restore 612, 618
        }
    }
}
