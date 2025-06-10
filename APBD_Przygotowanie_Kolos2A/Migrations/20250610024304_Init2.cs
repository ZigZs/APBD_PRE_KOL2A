using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD_Przygotowanie_Kolos2A.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Available_Program",
                keyColumn: "AvailableProgramId",
                keyValue: 1,
                column: "Price",
                value: 26m);

            migrationBuilder.UpdateData(
                table: "Purchase_History",
                keyColumns: new[] { "AvailableProgramId", "CustomerId" },
                keyValues: new object[] { 1, 1 },
                column: "PurchaseDate",
                value: new DateTime(2025, 6, 10, 4, 43, 4, 234, DateTimeKind.Local).AddTicks(2557));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Available_Program",
                keyColumn: "AvailableProgramId",
                keyValue: 1,
                column: "Price",
                value: 25m);

            migrationBuilder.UpdateData(
                table: "Purchase_History",
                keyColumns: new[] { "AvailableProgramId", "CustomerId" },
                keyValues: new object[] { 1, 1 },
                column: "PurchaseDate",
                value: new DateTime(2025, 6, 10, 3, 10, 27, 954, DateTimeKind.Local).AddTicks(2061));
        }
    }
}
