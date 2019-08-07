using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class changedEmpTableStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AbpUsers_Id",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<long>(
                name: "ManagerId",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AbpUsers_Id",
                table: "Employees",
                column: "Id",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
