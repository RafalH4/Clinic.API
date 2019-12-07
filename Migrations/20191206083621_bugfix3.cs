using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.API.Migrations
{
    public partial class bugfix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Departments_DepartmentId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_MedOffices_Departments_departmentId",
                table: "MedOffices");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_DepartmentId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "departmentId",
                table: "MedOffices",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_MedOffices_departmentId",
                table: "MedOffices",
                newName: "IX_MedOffices_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedOffices_Departments_DepartmentId",
                table: "MedOffices",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedOffices_Departments_DepartmentId",
                table: "MedOffices");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "MedOffices",
                newName: "departmentId");

            migrationBuilder.RenameIndex(
                name: "IX_MedOffices_DepartmentId",
                table: "MedOffices",
                newName: "IX_MedOffices_departmentId");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_DepartmentId",
                table: "Contracts",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Departments_DepartmentId",
                table: "Contracts",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedOffices_Departments_departmentId",
                table: "MedOffices",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
