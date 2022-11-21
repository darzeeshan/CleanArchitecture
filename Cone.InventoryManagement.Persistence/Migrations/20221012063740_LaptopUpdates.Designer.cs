﻿// <auto-generated />
using System;
using Cone.InventoryManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cone.InventoryManagement.Persistence.Migrations
{
    [DbContext(typeof(ConeDatabaseContext))]
    [Migration("20221012063740_LaptopUpdates")]
    partial class LaptopUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cone.InventoryManagement.Domain.Entities.tblMapClientConnection", b =>
                {
                    b.Property<int>("intClientConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("intClientConnectionId"), 1L, 1);

                    b.Property<byte>("bytConnectionType")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("dtDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dtLastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("intClientSetupId")
                        .HasColumnType("int");

                    b.Property<string>("txtKey")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("txtPassword")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("txtPort")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("VARCHAR(5)");

                    b.Property<string>("txtUsername")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("intClientConnectionId");

                    b.ToTable("tblMapClientConnection");
                });

            modelBuilder.Entity("Cone.InventoryManagement.Domain.Entities.tblMapClientFile", b =>
                {
                    b.Property<int>("intClientFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("intClientFileId"), 1L, 1);

                    b.Property<bool>("blnFileColumnRequired")
                        .HasColumnType("bit");

                    b.Property<bool>("blnReferenceNumber")
                        .HasColumnType("bit");

                    b.Property<byte>("bytFileType")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("dtDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dtLastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("intClientSetupId")
                        .HasColumnType("int");

                    b.Property<string>("txtFileColumn")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("VARCHAR(35)");

                    b.Property<string>("txtMapWithNode")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("VARCHAR(35)");

                    b.HasKey("intClientFileId");

                    b.ToTable("tblMapClientFile");
                });

            modelBuilder.Entity("Cone.InventoryManagement.Domain.Entities.tblMapClientSetup", b =>
                {
                    b.Property<int>("intClientSetupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("intClientSetupId"), 1L, 1);

                    b.Property<byte>("bytStatus")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("dtDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("txtClientId")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR(15)");

                    b.Property<string>("txtClientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("txtFolderLocation")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("txtProcessedFolderLocation")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("intClientSetupId");

                    b.ToTable("tblMapClientSetup");
                });
#pragma warning restore 612, 618
        }
    }
}
