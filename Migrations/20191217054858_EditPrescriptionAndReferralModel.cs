using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.API.Migrations
{
    public partial class EditPrescriptionAndReferralModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Treatment",
                table: "Referrals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Drug",
                table: "Prescriptions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Treatment",
                table: "Referrals");

            migrationBuilder.DropColumn(
                name: "Drug",
                table: "Prescriptions");
        }
    }
}
