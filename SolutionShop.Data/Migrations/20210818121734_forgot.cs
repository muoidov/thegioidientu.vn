using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolutionShop.Data.Migrations
{
    public partial class forgot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForgotPasswords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Quên mật khẩu")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgotPasswords", x => x.Id);
                });

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

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Cras justo odio");

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Cras justo odio");

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Cras justo odio,");

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Cras justo odio,");

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Cras justo odio,");

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Cras justo odio, ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForgotPasswords");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d529fb1-5cc0-4c3b-9515-38da1dbe5fff"),
                column: "ConcurrencyStamp",
                value: "37e09399-5afb-4588-b1f7-f98500f06149");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a694485e-a98d-42f6-84d9-c0b4c7a2f27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d426d034-3737-4ae2-ad95-3992d3c0f9de", "AQAAAAEAACcQAAAAED7F6WgwgkxS6yri7ZHLYSeqTq3xh+XcO70yQYXjov7zi1ROLLrrzKsukLpAxRCVVA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 14, 0, 47, 23, 668, DateTimeKind.Local).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.");

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.");

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.");

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.");

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.");

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.");
        }
    }
}
