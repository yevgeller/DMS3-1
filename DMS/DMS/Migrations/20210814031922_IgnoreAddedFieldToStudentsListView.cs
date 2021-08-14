using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class IgnoreAddedFieldToStudentsListView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "AssignedGuardianCount",
            //    table: "Students_List",
            //    type: "INTEGER",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "AssignedGuardianCount",
            //    table: "Students_List");
        }
    }
}
