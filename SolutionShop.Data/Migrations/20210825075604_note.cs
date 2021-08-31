using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolutionShop.Data.Migrations
{
    public partial class note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d529fb1-5cc0-4c3b-9515-38da1dbe5fff"),
                column: "ConcurrencyStamp",
                value: "b20933a6-863a-492d-a744-5bee8f7753c6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a694485e-a98d-42f6-84d9-c0b4c7a2f27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "477cfa2c-db66-4d51-b9ac-6eceaebc5720", "AQAAAAEAACcQAAAAEO0A7bu+N7Vy4Cmb6QO6wllSvtl5LU0zSueRB6kNLatmAkTreurCkaN+DHOLWWbQYw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 25, 14, 56, 3, 357, DateTimeKind.Local).AddTicks(9617));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d529fb1-5cc0-4c3b-9515-38da1dbe5fff"),
                column: "ConcurrencyStamp",
                value: "8e16c622-8dc2-425c-983a-1e0c17446493");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a694485e-a98d-42f6-84d9-c0b4c7a2f27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8177816-a584-4605-908a-d9a0c41f2dec", "AQAAAAEAACcQAAAAEBAxW84ZLiD4rqW47z8MJMTLq6bnyE93XLuP/fT9Geb9p2nokhlt+nydt3SVaYKFiA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 25, 14, 35, 40, 550, DateTimeKind.Local).AddTicks(9227));
        }
    }
}
