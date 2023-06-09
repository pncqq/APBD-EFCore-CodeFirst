using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CW9.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 5, 20, 18, 36, 55, 637, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RefreshToken", "RefreshTokenExp" },
                values: new object[] { null, null });
        }
    }
}
