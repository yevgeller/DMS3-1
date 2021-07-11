using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class ContactAndPersonTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact_Type",
                columns: table => new
                {
                    Contact_Type_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact_Type", x => x.Contact_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Person_Type",
                columns: table => new
                {
                    Person_Type_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_Type", x => x.Person_Type_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact_Type");

            migrationBuilder.DropTable(
                name: "Person_Type");
        }
    }
}
