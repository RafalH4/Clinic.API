using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.API.Migrations
{
    public partial class ExampleData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("339f19a6-a200-4c7d-8080-0e15d83a2fc0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cb903673-0b5c-461f-9dcc-210239c8e63e"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreatedAt", "Discriminator", "Email", "FirstName", "HouseNumber", "Password", "Pesel", "PhoneNumber", "PostCode", "Role", "SecondName", "Street" },
                values: new object[] { new Guid("cb903673-0b5c-461f-9dcc-210239c8e63e"), "", new DateTime(2019, 10, 29, 7, 48, 27, 149, DateTimeKind.Utc).AddTicks(3934), "Doctor", "user1@o2.pl", "Jan", "", "pass", "", "", "", "doctor", "", "" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreatedAt", "Discriminator", "Email", "FirstName", "HouseNumber", "Password", "Pesel", "PhoneNumber", "PostCode", "Role", "SecondName", "Street" },
                values: new object[] { new Guid("339f19a6-a200-4c7d-8080-0e15d83a2fc0"), "", new DateTime(2019, 10, 29, 7, 48, 27, 150, DateTimeKind.Utc).AddTicks(4280), "Doctor", "user1@o2.pl", "Jan", "", "pass", "", "", "", "doctor", "Kowalski", "" });
        }
    }
}
