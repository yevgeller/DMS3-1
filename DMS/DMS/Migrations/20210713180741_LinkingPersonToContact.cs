using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class LinkingPersonToContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Person_Id",
                table: "Contact",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Person_Id",
                table: "Contact",
                column: "Person_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Person_Person_Id",
                table: "Contact",
                column: "Person_Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Person_Person_Id",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_Person_Id",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Person_Id",
                table: "Contact");
        }
    }
}
