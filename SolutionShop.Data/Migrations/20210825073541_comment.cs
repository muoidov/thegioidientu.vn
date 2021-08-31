using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolutionShop.Data.Migrations
{
    public partial class comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

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
    }
}
