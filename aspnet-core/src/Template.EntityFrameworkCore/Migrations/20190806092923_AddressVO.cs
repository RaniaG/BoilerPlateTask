using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class AddressVO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppartmentNumber",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullAddress",
                table: "Employees",
                maxLength: 600,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppartmentNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FullAddress",
                table: "Employees");
        }
    }
}
