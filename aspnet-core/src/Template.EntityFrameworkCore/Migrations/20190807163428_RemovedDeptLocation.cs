using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class RemovedDeptLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Building",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Building",
                table: "Departments",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Departments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
