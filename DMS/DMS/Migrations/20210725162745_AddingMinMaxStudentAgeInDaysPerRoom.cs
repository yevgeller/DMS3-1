using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class AddingMinMaxStudentAgeInDaysPerRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxStudentAgeInDays",
                table: "Room",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinStudentAgeInDays",
                table: "Room",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxStudentAgeInDays",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "MinStudentAgeInDays",
                table: "Room");
        }
    }
}
