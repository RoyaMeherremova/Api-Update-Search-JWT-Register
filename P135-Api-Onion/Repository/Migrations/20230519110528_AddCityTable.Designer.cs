﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Data;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230519110528_AddCityTable")]
    partial class AddCityTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Domain.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 5, 19, 15, 5, 28, 317, DateTimeKind.Local).AddTicks(670),
                            Name = "Azerbaycan",
                            SoftDelete = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 5, 19, 15, 5, 28, 317, DateTimeKind.Local).AddTicks(672),
                            Name = "Turkiye",
                            SoftDelete = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 5, 19, 15, 5, 28, 317, DateTimeKind.Local).AddTicks(673),
                            Name = "Ingiltere",
                            SoftDelete = false
                        });
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Sumqayit",
                            Age = 27,
                            CreatedAt = new DateTime(2023, 5, 19, 15, 5, 28, 317, DateTimeKind.Local).AddTicks(457),
                            FullName = "Roya Meherremova",
                            SoftDelete = false
                        },
                        new
                        {
                            Id = 2,
                            Address = "Xetai",
                            Age = 28,
                            CreatedAt = new DateTime(2023, 5, 19, 15, 5, 28, 317, DateTimeKind.Local).AddTicks(470),
                            FullName = "Anar Aliyev",
                            SoftDelete = false
                        },
                        new
                        {
                            Id = 3,
                            Address = "Nesimi",
                            Age = 18,
                            CreatedAt = new DateTime(2023, 5, 19, 15, 5, 28, 317, DateTimeKind.Local).AddTicks(520),
                            FullName = "Mubariz Agayev",
                            SoftDelete = false
                        });
                });

            modelBuilder.Entity("Domain.Models.City", b =>
                {
                    b.HasOne("Domain.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
