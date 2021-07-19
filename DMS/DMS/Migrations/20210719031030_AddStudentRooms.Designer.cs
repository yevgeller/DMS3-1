﻿// <auto-generated />
using System;
using DMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DMS.Migrations
{
    [DbContext(typeof(DMSDataContext))]
    [Migration("20210719031030_AddStudentRooms")]
    partial class AddStudentRooms
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

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

            modelBuilder.Entity("DMS.Models.Contact", b =>
                {
                    b.Property<int>("Contact_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Contact_Type_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Person_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Contact_Id");

                    b.HasIndex("Contact_Type_Id");

                    b.HasIndex("Person_Id");

                    b.ToTable("Contact");
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

            modelBuilder.Entity("DMS.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("Person_Type_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Person_Type_Id");

                    b.ToTable("Person");
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

            modelBuilder.Entity("DMS.Models.Room", b =>
                {
                    b.Property<int>("Room_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age_Bracket_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Room_Id");

                    b.HasIndex("Age_Bracket_Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("DMS.Models.Student", b =>
                {
                    b.Property<int>("Student_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Student_Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("DMS.Models.Student_Room", b =>
                {
                    b.Property<int>("Student_Room_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Room_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Student_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Student_Room_Id");

                    b.HasIndex("Room_Id");

                    b.HasIndex("Student_Id");

                    b.ToTable("Student_Rooms");
                });

            modelBuilder.Entity("DMS.Models.Contact", b =>
                {
                    b.HasOne("DMS.Models.Contact_Type", "Contact_Type")
                        .WithMany()
                        .HasForeignKey("Contact_Type_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DMS.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("Person_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact_Type");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("DMS.Models.Person", b =>
                {
                    b.HasOne("DMS.Models.Person_Type", "Person_Type")
                        .WithMany()
                        .HasForeignKey("Person_Type_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person_Type");
                });

            modelBuilder.Entity("DMS.Models.Room", b =>
                {
                    b.HasOne("DMS.Models.Age_Bracket", "Age_Bracket")
                        .WithMany()
                        .HasForeignKey("Age_Bracket_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Age_Bracket");
                });

            modelBuilder.Entity("DMS.Models.Student_Room", b =>
                {
                    b.HasOne("DMS.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("Room_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DMS.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
