using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.API.Migrations
{
    public partial class MedOfficeBugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_MedOffices_Departments_departmentId",
                table: "MedOffices",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedOffices_Departments_departmentId",
                table: "MedOffices");

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
