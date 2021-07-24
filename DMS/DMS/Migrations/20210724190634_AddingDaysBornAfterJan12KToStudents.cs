using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class AddingDaysBornAfterJan12KToStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BornDaysAfterJan12000",
                table: "Student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BornDaysAfterJan12000",
                table: "Student");
        }
    }
}
