using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class IgnoreAddedFieldToGuardiansListView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "AssignedStudentsCount",
            //    table: "Guardians_List",
            //    type: "INTEGER",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "AssignedStudentsCount",
            //    table: "Guardians_List");
        }
    }
}
