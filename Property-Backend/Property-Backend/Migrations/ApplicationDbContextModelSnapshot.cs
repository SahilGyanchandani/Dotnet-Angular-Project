﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Property_Backend.Data;

#nullable disable

namespace Property_Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Property_Backend.Model.City", b =>
                {
                    b.Property<int>("cityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("cityId"));

                    b.Property<string>("cityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("cityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            cityId = 1,
                            cityName = "Surat",
                            createdDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isDeleted = false,
                            updatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            cityId = 2,
                            cityName = "Ahmedabad",
                            createdDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isDeleted = false,
                            updatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            cityId = 3,
                            cityName = "Vadodara",
                            createdDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isDeleted = false,
                            updatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            cityId = 4,
                            cityName = "Pune",
                            createdDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isDeleted = false,
                            updatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
