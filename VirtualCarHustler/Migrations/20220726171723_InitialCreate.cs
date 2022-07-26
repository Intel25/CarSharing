using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualCarHustler.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VehList",
                table: "VehList");

            migrationBuilder.RenameTable(
                name: "VehList",
                newName: "Vehicles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "VehList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehList",
                table: "VehList",
                column: "Id");
        }
    }
}
