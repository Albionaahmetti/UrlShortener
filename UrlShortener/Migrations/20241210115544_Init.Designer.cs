﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlShortener.AppDbContext;

#nullable disable

namespace UrlShortener.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241210115544_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UrlShortener.Classes.UrlItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClickCounter")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LongUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UrlItems");
                });
#pragma warning restore 612, 618
        }
    }
}
