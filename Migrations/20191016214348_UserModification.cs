using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.API.Migrations
{
    public partial class UserModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pesel",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pesel",
                table: "Nurses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pesel",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pesel",
                table: "Departments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "Departments");
        }
    }
}
