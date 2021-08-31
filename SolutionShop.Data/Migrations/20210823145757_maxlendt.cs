using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolutionShop.Data.Migrations
{
    public partial class maxlendt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d529fb1-5cc0-4c3b-9515-38da1dbe5fff"),
                column: "ConcurrencyStamp",
                value: "788a0697-9c51-4aaf-8d37-8f67ff0dd5d2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a694485e-a98d-42f6-84d9-c0b4c7a2f27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21e7261f-691e-4bd9-b3b4-e763fd67e316", "AQAAAAEAACcQAAAAEBxvx3cobaWB0y8yXNJiILM9sbImD0XLkK0Hi5ikiDvx2kbj/F0Q8Y9X36UB13+Rcw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 23, 21, 57, 56, 77, DateTimeKind.Local).AddTicks(7931));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "ProductTranslations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d529fb1-5cc0-4c3b-9515-38da1dbe5fff"),
                column: "ConcurrencyStamp",
                value: "60f5ac9e-e365-4f85-9e52-4d699ac9acb2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a694485e-a98d-42f6-84d9-c0b4c7a2f27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a98c9b0e-510b-4389-b661-3d927d73ae76", "AQAAAAEAACcQAAAAENiMfOLVHwB8bXGiRYpI20ezpa+Pvn5v3Z6MnO1nDL/b2WyazWdt0aRbjB2D76yvQA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 18, 19, 17, 33, 33, DateTimeKind.Local).AddTicks(3651));
        }
    }
}
