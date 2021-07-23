using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class RenamePersonIdToPersonPerson_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "Person_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Person_Id",
                table: "Person",
                newName: "Id");
        }
    }
}
