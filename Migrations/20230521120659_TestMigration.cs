using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CW9.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 5, 21, 14, 6, 58, 985, DateTimeKind.Local).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RefreshToken", "RefreshTokenExp" },
                values: new object[] { "kvqhPjuMSYbvue6BUcFoadizOnLiKUTd7CYC7RwzH9gzUYqU04N8YDCJw4yBaPvejCI=", new DateTime(2023, 5, 31, 14, 6, 58, 985, DateTimeKind.Local).AddTicks(9904) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 5, 20, 20, 35, 55, 14, DateTimeKind.Local).AddTicks(7592));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RefreshToken", "RefreshTokenExp" },
                values: new object[] { "Re4vvukVxq+PVK1rMAZUKQK2vClD7CngsQCfOMHFLSCaDWCk9Nesu5uw0ZYJBe7df55/GGKXEcxn8gzyJHKzUNYt7WdIfK/58IvmkdLl1fOMObh5ybZNL0nWiOkIXSAYaRz5+A==", new DateTime(2023, 5, 30, 20, 35, 55, 14, DateTimeKind.Local).AddTicks(8300) });
        }
    }
}
