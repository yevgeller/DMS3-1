using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class IgnoreAddedPersonnelContact_List : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "PersonnelContact_List",
            //    columns: table => new
            //    {
            //        Contact_Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Contact_Type_Id = table.Column<int>(type: "INTEGER", nullable: false),
            //        Contact_Type_Name = table.Column<string>(type: "TEXT", nullable: true),
            //        Value = table.Column<string>(type: "TEXT", nullable: true),
            //        Person_Id = table.Column<int>(type: "INTEGER", nullable: false),
            //        Person_Name = table.Column<string>(type: "TEXT", nullable: true),
            //        Person_Type_Id = table.Column<int>(type: "INTEGER", nullable: false),
            //        Person_Type_Name = table.Column<string>(type: "TEXT", nullable: true),
            //        Is_Active = table.Column<bool>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PersonnelContact_List", x => x.Contact_Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "PersonnelContact_List");
        }
    }
}
