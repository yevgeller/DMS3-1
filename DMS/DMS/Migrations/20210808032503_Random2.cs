using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class Random2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "MaxStudentAgeInDays",
            //    table: "Room");

            //migrationBuilder.DropColumn(
            //    name: "MinStudentAgeInDays",
            //    table: "Room");

            //migrationBuilder.CreateTable(
            //    name: "Parent_Student",
            //    columns: table => new
            //    {
            //        Person_Student_Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Person_Id = table.Column<int>(type: "INTEGER", nullable: false),
            //        Student_Id = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Parent_Student", x => x.Person_Student_Id);
            //        table.ForeignKey(
            //            name: "FK_Parent_Student_Person_Person_Id",
            //            column: x => x.Person_Id,
            //            principalTable: "Person",
            //            principalColumn: "Person_Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Parent_Student_Student_Student_Id",
            //            column: x => x.Student_Id,
            //            principalTable: "Student",
            //            principalColumn: "Student_Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Students_List",
            //    columns: table => new
            //    {
            //        Student_Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Student_Name = table.Column<string>(type: "TEXT", nullable: true),
            //        Birthdate = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        Is_Active = table.Column<bool>(type: "INTEGER", nullable: false),
            //        BornDaysAfterJan12000 = table.Column<int>(type: "INTEGER", nullable: false),
            //        AssignedToRooms = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Students_List", x => x.Student_Id);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Parent_Student_Person_Id",
            //    table: "Parent_Student",
            //    column: "Person_Id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Parent_Student_Student_Id",
            //    table: "Parent_Student",
            //    column: "Student_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Parent_Student");

            //migrationBuilder.DropTable(
            //    name: "Students_List");

            //migrationBuilder.AddColumn<int>(
            //    name: "MaxStudentAgeInDays",
            //    table: "Room",
            //    type: "INTEGER",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "MinStudentAgeInDays",
            //    table: "Room",
            //    type: "INTEGER",
            //    nullable: false,
            //    defaultValue: 0);
        }
    }
}
