using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkAggregator.Migrations
{
    public partial class LoginNotw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "CreationDate", "Creator", "Points", "Title", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, "Strona internetowa wp", "https://www.wp.pl" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -1, "Strona internetowa onet", "https://www.onet.pl" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Strona internetowa yt", "https://www.youtube.pl" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1123, "Strona internetowa fb", "https://www.fb.pl" }
                });
        }
    }
}
