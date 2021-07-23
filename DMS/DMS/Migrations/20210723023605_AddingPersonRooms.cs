using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class AddingPersonRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person_Room",
                columns: table => new
                {
                    Person_Room_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Person_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Room_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_Room", x => x.Person_Room_Id);
                    table.ForeignKey(
                        name: "FK_Person_Room_Person_Person_Id",
                        column: x => x.Person_Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_Room_Room_Room_Id",
                        column: x => x.Room_Id,
                        principalTable: "Room",
                        principalColumn: "Room_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_Room_Person_Id",
                table: "Person_Room",
                column: "Person_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Room_Room_Id",
                table: "Person_Room",
                column: "Room_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person_Room");
        }
    }
}
