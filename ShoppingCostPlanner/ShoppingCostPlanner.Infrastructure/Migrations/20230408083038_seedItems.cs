using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCostPlanner.Infrastructure.Migrations
{
    public partial class seedItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "IsCompleted", "Name", "Price", "Quantity", "StoreId" },
                values: new object[,]
                {
                    { 1, 1, "Whole Milk", false, "Milk", 2.99m, 1, 1 },
                    { 2, 1, "Wheat Bread", false, "Bread", 1.99m, 2, 2 },
                    { 3, 1, "Organic Large Eggs", false, "Eggs", 1.99m, 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 8, 11, 30, 37, 926, DateTimeKind.Local).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 8, 11, 30, 37, 926, DateTimeKind.Local).AddTicks(1462));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 8, 11, 26, 57, 560, DateTimeKind.Local).AddTicks(3482));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 8, 11, 26, 57, 560, DateTimeKind.Local).AddTicks(3523));
        }
    }
}
