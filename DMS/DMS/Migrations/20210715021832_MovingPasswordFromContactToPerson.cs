using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class MovingPasswordFromContactToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Person",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Contact",
                type: "TEXT",
                nullable: true);
        }
    }
}
