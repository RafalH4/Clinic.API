using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.API.Migrations
{
    public partial class EditUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("91ca47da-38d1-40e8-852d-b70d13d1abc3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf2878a5-cc9f-4695-adfc-3a8120bb7b53"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c9f61e9b-1c9c-482d-b759-c0682526b2ad"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d259f930-0f3b-49f9-b050-499a8271127d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1de2bec-cc76-443f-94f4-e45d58f870d8"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreatedAt", "Discriminator", "Email", "FirstName", "HouseNumber", "Password", "Pesel", "PhoneNumber", "PostCode", "Role", "SecondName", "Street" },
                values: new object[,]
                {
                    { new Guid("f1de2bec-cc76-443f-94f4-e45d58f870d8"), "", new DateTime(2019, 10, 29, 7, 49, 48, 586, DateTimeKind.Utc).AddTicks(902), "Doctor", "user1@o2.pl", "Jan", "", "pass", "", "", "", "doctor", "", "" },
                    { new Guid("91ca47da-38d1-40e8-852d-b70d13d1abc3"), "", new DateTime(2019, 10, 29, 7, 49, 48, 586, DateTimeKind.Utc).AddTicks(9665), "Doctor", "user1@o2.pl", "Jan", "", "pass", "", "", "", "doctor", "Kowalski", "" },
                    { new Guid("d259f930-0f3b-49f9-b050-499a8271127d"), "", new DateTime(2019, 10, 29, 7, 49, 48, 586, DateTimeKind.Utc).AddTicks(9791), "Doctor", "user2@o2.pl", "Piotr", "", "pass", "", "", "", "doctor", "Nowak", "" },
                    { new Guid("c9f61e9b-1c9c-482d-b759-c0682526b2ad"), "", new DateTime(2019, 10, 29, 7, 49, 48, 586, DateTimeKind.Utc).AddTicks(9796), "Doctor", "user3@o2.pl", "Paweł", "", "pass", "", "", "", "doctor", "Szczery", "" },
                    { new Guid("bf2878a5-cc9f-4695-adfc-3a8120bb7b53"), "", new DateTime(2019, 10, 29, 7, 49, 48, 586, DateTimeKind.Utc).AddTicks(9798), "Doctor", "user4@o2.pl", "Andrzej", "", "pass", "", "", "", "doctor", "Kosień", "" }
                });
        }
    }
}
