using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TopLearn.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInWallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Wallets");

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Amount", "CreateDate", "Description", "IsPay", "UserId", "WalletTypeId" },
                values: new object[,]
                {
                    { 1, 2000000, new DateTime(2024, 10, 12, 11, 11, 15, 283, DateTimeKind.Local).AddTicks(8009), "شارژ حساب", true, 12, 1 },
                    { 2, 500000, new DateTime(2024, 10, 12, 11, 11, 15, 283, DateTimeKind.Local).AddTicks(8020), "شارژ حساب", true, 12, 1 },
                    { 3, 650000, new DateTime(2024, 10, 12, 11, 11, 15, 283, DateTimeKind.Local).AddTicks(8022), "خرید دوره", true, 12, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Wallets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
