﻿// <auto-generated />
using System;
using BTRS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTRS.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    [Migration("20240110204911_fm")]
    partial class fm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BTRS.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("admin");
                });

            modelBuilder.Entity("BTRS.Models.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CaptinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FK_Bus_Admin")
                        .HasColumnType("int");

                    b.Property<int>("FK_Bus_Trip")
                        .HasColumnType("int");

                    b.Property<int>("Num_of_S")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_Bus_Admin");

                    b.HasIndex("FK_Bus_Trip");

                    b.ToTable("bus");
                });

            modelBuilder.Entity("BTRS.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerId");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("passenger");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusNum")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndD")
                        .HasColumnType("datetime2");

                    b.Property<int>("FK_Admin_Trip")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartD")
                        .HasColumnType("datetime2");

                    b.Property<string>("dest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FK_Admin_Trip");

                    b.ToTable("trip");
                });

            modelBuilder.Entity("BTRS.Models.Trip_Passenger", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("FK_Passenger")
                        .HasColumnType("int");

                    b.Property<int>("FK_Trip")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FK_Passenger");

                    b.HasIndex("FK_Trip");

                    b.ToTable("Trip_Passenger");
                });

            modelBuilder.Entity("BTRS.Models.Bus", b =>
                {
                    b.HasOne("BTRS.Models.Admin", "admin")
                        .WithMany("bus")
                        .HasForeignKey("FK_Bus_Admin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.Trip", "trip")
                        .WithMany("bus")
                        .HasForeignKey("FK_Bus_Trip")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("admin");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.HasOne("BTRS.Models.Admin", "admin")
                        .WithMany("Trip")
                        .HasForeignKey("FK_Admin_Trip")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("admin");
                });

            modelBuilder.Entity("BTRS.Models.Trip_Passenger", b =>
                {
                    b.HasOne("BTRS.Models.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("FK_Passenger")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.Trip", "trip")
                        .WithMany()
                        .HasForeignKey("FK_Trip")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.Admin", b =>
                {
                    b.Navigation("Trip");

                    b.Navigation("bus");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.Navigation("bus");
                });
#pragma warning restore 612, 618
        }
    }
}
