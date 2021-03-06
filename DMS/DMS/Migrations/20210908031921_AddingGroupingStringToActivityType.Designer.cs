// <auto-generated />
using System;
using DMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DMS.Migrations
{
    [DbContext(typeof(DMSDataContext))]
    [Migration("20210908031921_AddingGroupingStringToActivityType")]
    partial class AddingGroupingStringToActivityType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("DMS.Models.Activity", b =>
                {
                    b.Property<int>("Activity_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Activity_Type_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Created_ByPerson_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Created_By_Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_On")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("TEXT");

                    b.Property<int>("Student_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Activity_Id");

                    b.HasIndex("Activity_Type_Id");

                    b.HasIndex("Created_ByPerson_Id");

                    b.HasIndex("Student_Id");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("DMS.Models.Activity_Type", b =>
                {
                    b.Property<int>("Activity_Type_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GroupingString")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("Activity_Type_Id");

                    b.ToTable("Activity_Type");
                });

            modelBuilder.Entity("DMS.Models.Age_Bracket", b =>
                {
                    b.Property<int>("Age_Bracket_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxDays")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinDays")
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

            modelBuilder.Entity("DMS.Models.Guardians_List", b =>
                {
                    b.Property<int>("Person_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AssignedStudents")
                        .HasColumnType("TEXT");

                    b.Property<int>("AssignedStudentsCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Person_Type_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Person_Id");

                    b.ToTable("Guardians_List");

                    b.ToView("Guardians_List");
                });

            modelBuilder.Entity("DMS.Models.Person", b =>
                {
                    b.Property<int>("Person_Id")
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

                    b.HasKey("Person_Id");

                    b.HasIndex("Person_Type_Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("DMS.Models.Person_Room", b =>
                {
                    b.Property<int>("Person_Room_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Person_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Room_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Person_Room_Id");

                    b.HasIndex("Person_Id");

                    b.HasIndex("Room_Id");

                    b.ToTable("Person_Room");
                });

            modelBuilder.Entity("DMS.Models.Person_Student", b =>
                {
                    b.Property<int>("Person_Student_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Person_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Student_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Person_Student_Id");

                    b.HasIndex("Person_Id");

                    b.HasIndex("Student_Id");

                    b.ToTable("Parent_Student");
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

            modelBuilder.Entity("DMS.Models.PersonnelContact_List", b =>
                {
                    b.Property<int>("Contact_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Contact_Type_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contact_Type_Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Person_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Person_Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Person_Type_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Person_Type_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Contact_Id");

                    b.ToTable("PersonnelContact_List");

                    b.ToView("PersonnelContact_List");
                });

            modelBuilder.Entity("DMS.Models.Persons_List", b =>
                {
                    b.Property<int>("Person_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GuardianToStudents")
                        .HasColumnType("TEXT");

                    b.Property<int>("GuardianToStudentsCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Person_Qualifier")
                        .HasColumnType("TEXT");

                    b.Property<int>("Person_Type_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Person_Type_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeacherRooms")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherRoomsCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Person_Id");

                    b.ToTable("Persons_List");

                    b.ToView("Persons_List");
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

            modelBuilder.Entity("DMS.Models.RoomGeneralInfo_List", b =>
                {
                    b.Property<int>("Room_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AvgStudentAgeInDays")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Oldest_Student_DaysOld")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Oldest_Student_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Oldest_Student_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Room_Bracket_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Room_Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Room_Is_Active")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Room_MaxCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Room_Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentsInRoom")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentsOutOfAgeBracket")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TAsInRoom")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeachersInRoom")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Youngest_Student_DaysOld")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Youngest_Student_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Youngest_Student_Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Room_Id");

                    b.ToView("RoomGeneralInfo_List");
                });

            modelBuilder.Entity("DMS.Models.Student", b =>
                {
                    b.Property<int>("Student_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<int>("BornDaysAfterJan12000")
                        .HasColumnType("INTEGER");

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

            modelBuilder.Entity("DMS.Models.Students_List", b =>
                {
                    b.Property<int>("Student_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssignedGuardianCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AssignedToParents")
                        .HasColumnType("TEXT");

                    b.Property<string>("AssignedToRooms")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<int>("BornDaysAfterJan12000")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DaysOld")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Student_Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Student_Id");

                    b.ToTable("Students_List");

                    b.ToView("Students_List");
                });

            modelBuilder.Entity("DMS.Models.Students_OutOfRoomAgeBracket_List", b =>
                {
                    b.Property<int>("Room_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age_Bracket_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Age_Bracket_Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Room_Bracket_MaxDays")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Room_Bracket_MinDays")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Room_Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Student_AgeInDays")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Student_AgeWithinRoomRange")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Student_Age_DaysOver")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Student_Age_DaysUnder")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Student_Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Student_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Student_Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Room_Id");

                    b.ToView("Students_OutOfRoomAgeBracket_List");
                });

            modelBuilder.Entity("DMS.Models.Activity", b =>
                {
                    b.HasOne("DMS.Models.Activity_Type", "Activity_Type")
                        .WithMany()
                        .HasForeignKey("Activity_Type_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DMS.Models.Person", "Created_By")
                        .WithMany()
                        .HasForeignKey("Created_ByPerson_Id");

                    b.HasOne("DMS.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity_Type");

                    b.Navigation("Created_By");

                    b.Navigation("Student");
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

            modelBuilder.Entity("DMS.Models.Person_Room", b =>
                {
                    b.HasOne("DMS.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("Person_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DMS.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("Room_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DMS.Models.Person_Student", b =>
                {
                    b.HasOne("DMS.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("Person_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DMS.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Student");
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
