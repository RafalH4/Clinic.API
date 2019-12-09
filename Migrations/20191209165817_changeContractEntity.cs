using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.API.Migrations
{
    public partial class changeContractEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Contracts",
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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Departments_DepartmentId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_DepartmentId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Contracts");
        }
    }
}
