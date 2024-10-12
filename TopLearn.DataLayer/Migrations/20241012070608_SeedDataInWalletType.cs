using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TopLearn.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInWalletType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WalletTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "واریز" },
                    { 2, "برداشت" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WalletTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WalletTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
