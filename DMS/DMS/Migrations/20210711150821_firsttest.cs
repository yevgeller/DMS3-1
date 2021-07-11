using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class firsttest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Age_Bracket",
                columns: table => new
                {
                    Age_Bracket_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Age_Bracket", x => x.Age_Bracket_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Age_Bracket");
        }
    }
}
