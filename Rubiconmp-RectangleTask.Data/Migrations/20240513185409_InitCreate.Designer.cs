﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Rubiconmp_RectangleTask.Data;

#nullable disable

namespace Rubiconmp_RectangleTask.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240513185409_InitCreate")]
    partial class InitCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Rubiconmp_RectangleTask.Data.Rectangle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("height");

                    b.Property<double>("Width")
                        .HasColumnType("double precision")
                        .HasColumnName("width");

                    b.Property<double>("X")
                        .HasColumnType("double precision")
                        .HasColumnName("x");

                    b.Property<double>("Y")
                        .HasColumnType("double precision")
                        .HasColumnName("y");

                    b.HasKey("Id")
                        .HasName("pk_rectangles");

                    b.ToTable("rectangles", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
