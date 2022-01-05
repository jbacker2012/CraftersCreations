﻿// <auto-generated />
using System;
using CraftersCreations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CraftersCreations.Migrations
{
    [DbContext(typeof(CraftDbContext))]
    [Migration("20220105220536_CraftTypes")]
    partial class CraftTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("CraftersCreations.Models.Catagory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Catagory");
                });

            modelBuilder.Entity("CraftersCreations.Models.CraftType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CatagoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CatagoryId");

                    b.ToTable("CraftType");
                });

            modelBuilder.Entity("CraftersCreations.Models.Materials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CatagoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CatagoryId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("CraftersCreations.Models.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CatagoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CatagoryId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CraftersCreations.Models.CraftType", b =>
                {
                    b.HasOne("CraftersCreations.Models.Catagory", "Catagory")
                        .WithMany()
                        .HasForeignKey("CatagoryId");

                    b.Navigation("Catagory");
                });

            modelBuilder.Entity("CraftersCreations.Models.Materials", b =>
                {
                    b.HasOne("CraftersCreations.Models.Catagory", "Catagory")
                        .WithMany()
                        .HasForeignKey("CatagoryId");

                    b.Navigation("Catagory");
                });

            modelBuilder.Entity("CraftersCreations.Models.Projects", b =>
                {
                    b.HasOne("CraftersCreations.Models.Catagory", "Catagory")
                        .WithMany()
                        .HasForeignKey("CatagoryId");

                    b.Navigation("Catagory");
                });
#pragma warning restore 612, 618
        }
    }
}
