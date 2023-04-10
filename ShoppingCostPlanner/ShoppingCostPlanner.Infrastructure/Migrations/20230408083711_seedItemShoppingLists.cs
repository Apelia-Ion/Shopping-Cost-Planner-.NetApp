using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCostPlanner.Infrastructure.Migrations
{
    public partial class seedItemShoppingLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ItemShoppingList",
                columns: new[] { "ItemId", "ShoppingListId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 8, 11, 37, 11, 657, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 8, 11, 37, 11, 657, DateTimeKind.Local).AddTicks(5249));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemShoppingList",
                keyColumns: new[] { "ItemId", "ShoppingListId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ItemShoppingList",
                keyColumns: new[] { "ItemId", "ShoppingListId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ItemShoppingList",
                keyColumns: new[] { "ItemId", "ShoppingListId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 8, 11, 36, 28, 250, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 8, 11, 36, 28, 250, DateTimeKind.Local).AddTicks(7547));
        }
    }
}
