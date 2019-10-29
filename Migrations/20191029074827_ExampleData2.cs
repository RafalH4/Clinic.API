using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.API.Migrations
{
    public partial class ExampleData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("12da7e78-a1e5-49dc-8f0d-66a47cb4f93d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("977246bb-ab8b-4b4b-81da-9189e661be8c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bb24cfa0-2fcc-4910-a091-661eb1fadda4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ff7206ff-a04f-414a-91d0-2f7bcfa95812"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreatedAt", "Discriminator", "Email", "FirstName", "HouseNumber", "Password", "Pesel", "PhoneNumber", "PostCode", "Role", "SecondName", "Street" },
                values: new object[] { new Guid("cb903673-0b5c-461f-9dcc-210239c8e63e"), "", new DateTime(2019, 10, 29, 7, 48, 27, 149, DateTimeKind.Utc).AddTicks(3934), "Doctor", "user1@o2.pl", "Jan", "", "pass", "", "", "", "doctor", "", "" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreatedAt", "Discriminator", "Email", "FirstName", "HouseNumber", "Password", "Pesel", "PhoneNumber", "PostCode", "Role", "SecondName", "Street" },
                values: new object[] { new Guid("339f19a6-a200-4c7d-8080-0e15d83a2fc0"), "", new DateTime(2019, 10, 29, 7, 48, 27, 150, DateTimeKind.Utc).AddTicks(4280), "Doctor", "user1@o2.pl", "Jan", "", "pass", "", "", "", "doctor", "Kowalski", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("977246bb-ab8b-4b4b-81da-9189e661be8c"), "", new DateTime(2019, 10, 29, 7, 41, 25, 674, DateTimeKind.Utc).AddTicks(3888), "Doctor", "user1@o2.pl", "Jan", "", "pass", "", "", "", "doctor", "Kowalski", "" },
                    { new Guid("12da7e78-a1e5-49dc-8f0d-66a47cb4f93d"), "", new DateTime(2019, 10, 29, 7, 41, 25, 675, DateTimeKind.Utc).AddTicks(2636), "Doctor", "user2@o2.pl", "Piotr", "", "pass", "", "", "", "doctor", "Nowak", "" },
                    { new Guid("bb24cfa0-2fcc-4910-a091-661eb1fadda4"), "", new DateTime(2019, 10, 29, 7, 41, 25, 675, DateTimeKind.Utc).AddTicks(2772), "Doctor", "user3@o2.pl", "Paweł", "", "pass", "", "", "", "doctor", "Szczery", "" },
                    { new Guid("ff7206ff-a04f-414a-91d0-2f7bcfa95812"), "", new DateTime(2019, 10, 29, 7, 41, 25, 675, DateTimeKind.Utc).AddTicks(2777), "Doctor", "user4@o2.pl", "Andrzej", "", "pass", "", "", "", "doctor", "Kosień", "" }
                });
        }
    }
}
