﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentAndSell.Car.API.Data.Context;

#nullable disable

namespace RentAndSell.Car.API.Migrations
{
    [DbContext(typeof(CarRentDbContext))]
    [Migration("20241113080030_AddColumnArabaIdArabaTarihcesi")]
    partial class AddColumnArabaIdArabaTarihcesi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RentAndSell.Car.API.Data.Entities.Concrete.Araba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MotorTipi")
                        .HasColumnType("int");

                    b.Property<int>("SanzimanTipi")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("YakitTuru")
                        .HasColumnType("int");

                    b.Property<short>("Yili")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Arabalar");
                });

            modelBuilder.Entity("RentAndSell.Car.API.Data.Entities.Concrete.ArabaTarihce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArabaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("IslemTipi")
                        .HasColumnType("int");

                    b.Property<DateTime>("IslemZamani")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MotorTipi")
                        .HasColumnType("int");

                    b.Property<int>("SanzimanTipi")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("YakitTuru")
                        .HasColumnType("int");

                    b.Property<short>("Yili")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("ArabaTarihcesi");
                });
#pragma warning restore 612, 618
        }
    }
}
