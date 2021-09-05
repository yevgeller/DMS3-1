using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Migrations
{
    public partial class Testing123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "DaysOld",
            //    table: "Students_List",
            //    type: "INTEGER",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "DaysOld",
            //    table: "Students_List");
        }
    }
}
