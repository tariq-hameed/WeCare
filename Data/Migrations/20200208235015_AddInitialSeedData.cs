using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeCare.Migrations
{
    public partial class AddInitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "FirstName", "LastName", "SocialSecurityNumber" },
                values: new object[] { 1, "Frans", "Engström", "890101-2010" });

            migrationBuilder.InsertData(
                table: "Journal",
                columns: new[] { "Id", "PatientId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "JournalEntry",
                columns: new[] { "Id", "Date", "Entry", "JournalId" },
                values: new object[] { 1, new DateTime(2020, 1, 3, 12, 15, 0, 0, DateTimeKind.Unspecified), @"
                Patient feels uneasy and restless. Administered 5 ml of valium.
            ", 1 });

            migrationBuilder.InsertData(
                table: "JournalEntry",
                columns: new[] { "Id", "Date", "Entry", "JournalId" },
                values: new object[] { 2, new DateTime(2020, 1, 14, 8, 30, 0, 0, DateTimeKind.Unspecified), @"
                Patient complaining about not being able to sleep.
            ", 1 });

            migrationBuilder.InsertData(
                table: "JournalEntry",
                columns: new[] { "Id", "Date", "Entry", "JournalId" },
                values: new object[] { 3, new DateTime(2020, 1, 23, 15, 15, 0, 0, DateTimeKind.Unspecified), @"
                Patient returns for checkup, feeling much better now.
            ", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Journal",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
