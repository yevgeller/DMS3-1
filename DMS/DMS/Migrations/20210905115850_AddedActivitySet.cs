using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class AddedActivitySet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Activity_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Student_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Activity_Type_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_On = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Created_By_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 2500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Activity_Id);
                    table.ForeignKey(
                        name: "FK_Activity_Activity_Type_Activity_Type_Id",
                        column: x => x.Activity_Type_Id,
                        principalTable: "Activity_Type",
                        principalColumn: "Activity_Type_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Person_Created_ByPerson_Id",
                        column: x => x.Created_By_Id,
                        principalTable: "Person",
                        principalColumn: "Person_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_Student_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Student",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Activity_Type_Id",
                table: "Activity",
                column: "Activity_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Created_ByPerson_Id",
                table: "Activity",
                column: "Created_By_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Student_Id",
                table: "Activity",
                column: "Student_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");
        }
    }
}
