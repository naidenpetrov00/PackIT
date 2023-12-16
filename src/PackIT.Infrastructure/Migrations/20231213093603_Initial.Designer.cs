﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PackIT.Infrastructure.EF.Contexts;

#nullable disable

namespace PackIT.Infrastructure.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    [Migration("20231213093603_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("packing")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PackIT.Domain.Entities.PackingList", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.Property<string>("localization")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Localization");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("PackingLists", "packing");
                });

            modelBuilder.Entity("PackIT.Domain.ValueObjects.PackingItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPacked")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PackingListId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PackingListId");

                    b.ToTable("PackingItems", "packing");
                });

            modelBuilder.Entity("PackIT.Domain.ValueObjects.PackingItem", b =>
                {
                    b.HasOne("PackIT.Domain.Entities.PackingList", null)
                        .WithMany("items")
                        .HasForeignKey("PackingListId");
                });

            modelBuilder.Entity("PackIT.Domain.Entities.PackingList", b =>
                {
                    b.Navigation("items");
                });
#pragma warning restore 612, 618
        }
    }
}