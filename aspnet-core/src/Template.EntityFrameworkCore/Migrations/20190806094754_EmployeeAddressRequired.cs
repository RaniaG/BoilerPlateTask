using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class EmployeeAddressRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullAddress",
                table: "Employees",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 600,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullAddress",
                table: "Employees",
                maxLength: 600,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 600);
        }
    }
}
