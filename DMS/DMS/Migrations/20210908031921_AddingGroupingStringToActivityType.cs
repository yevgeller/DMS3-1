using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class AddingGroupingStringToActivityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupingString",
                table: "Activity_Type",
                type: "TEXT",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupingString",
                table: "Activity_Type");
        }
    }
}
