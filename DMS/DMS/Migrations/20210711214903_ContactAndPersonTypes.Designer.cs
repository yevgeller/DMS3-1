﻿// <auto-generated />
using DMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DMS.Migrations
{
    [DbContext(typeof(DMSDataContext))]
    [Migration("20210711214903_ContactAndPersonTypes")]
    partial class ContactAndPersonTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("DMS.Models.Activity_Type", b =>
                {
                    b.Property<int>("Activity_Type_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Activity_Type_Id");

                    b.ToTable("Activity_Type");
                });

            modelBuilder.Entity("DMS.Models.Age_Bracket", b =>
                {
                    b.Property<int>("Age_Bracket_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Age_Bracket_Id");

                    b.ToTable("Age_Bracket");
                });

            modelBuilder.Entity("DMS.Models.Contact_Type", b =>
                {
                    b.Property<int>("Contact_Type_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Contact_Type_Id");

                    b.ToTable("Contact_Type");
                });

            modelBuilder.Entity("DMS.Models.Person_Type", b =>
                {
                    b.Property<int>("Person_Type_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Person_Type_Id");

                    b.ToTable("Person_Type");
                });
#pragma warning restore 612, 618
        }
    }
}
