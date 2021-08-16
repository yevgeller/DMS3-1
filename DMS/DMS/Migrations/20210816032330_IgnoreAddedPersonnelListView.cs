using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class IgnoreAddedPersonnelListView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Persons_List",
            //    columns: table => new
            //    {
            //        Person_Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Name = table.Column<string>(type: "TEXT", nullable: true),
            //        Is_Active = table.Column<bool>(type: "INTEGER", nullable: false),
            //        Person_Type_Id = table.Column<int>(type: "INTEGER", nullable: false),
            //        Person_Type_Name = table.Column<string>(type: "TEXT", nullable: true),
            //        TeacherRooms = table.Column<string>(type: "TEXT", nullable: true),
            //        TeacherRoomsCount = table.Column<int>(type: "INTEGER", nullable: false),
            //        GuardianToStudents = table.Column<string>(type: "TEXT", nullable: true),
            //        GuardianToStudentsCount = table.Column<int>(type: "INTEGER", nullable: false),
            //        Person_Qualifier = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Persons_List", x => x.Person_Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Persons_List");
        }
    }
}
