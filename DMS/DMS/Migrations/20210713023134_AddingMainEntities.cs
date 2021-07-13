using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class AddingMainEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Contact_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Contact_Type_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Contact_Id);
                    table.ForeignKey(
                        name: "FK_Contact_Contact_Type_Contact_Type_Id",
                        column: x => x.Contact_Type_Id,
                        principalTable: "Contact_Type",
                        principalColumn: "Contact_Type_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Is_Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    Person_Type_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Person_Type_Person_Type_Id",
                        column: x => x.Person_Type_Id,
                        principalTable: "Person_Type",
                        principalColumn: "Person_Type_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Room_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MaxCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Age_Bracket_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Is_Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Room_Id);
                    table.ForeignKey(
                        name: "FK_Room_Age_Bracket_Age_Bracket_Id",
                        column: x => x.Age_Bracket_Id,
                        principalTable: "Age_Bracket",
                        principalColumn: "Age_Bracket_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Is_Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Student_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Contact_Type_Id",
                table: "Contact",
                column: "Contact_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Person_Type_Id",
                table: "Person",
                column: "Person_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Age_Bracket_Id",
                table: "Room",
                column: "Age_Bracket_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
