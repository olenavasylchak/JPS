using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class SeedPolls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Polls",
                columns: new[] { "Id", "CategoryId", "Description", "FinishesAt", "IsAnonymous", "StartsAt", "Title" },
                values: new object[] { 1, 2, "It`s an ESAT 2019 poll.", new DateTimeOffset(new DateTime(2019, 10, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), false, new DateTimeOffset(new DateTime(2019, 10, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "ESAT 2019" });

            migrationBuilder.InsertData(
                table: "Polls",
                columns: new[] { "Id", "CategoryId", "Description", "FinishesAt", "IsAnonymous", "StartsAt", "Title" },
                values: new object[] { 2, 2, "It`s an ESAT 2020 poll.", new DateTimeOffset(new DateTime(2019, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), false, new DateTimeOffset(new DateTime(2020, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "ESAT 2020" });

            migrationBuilder.InsertData(
                table: "Polls",
                columns: new[] { "Id", "CategoryId", "Description", "FinishesAt", "IsAnonymous", "StartsAt", "Title" },
                values: new object[] { 3, 1, "It`s an anonymous poll.", new DateTimeOffset(new DateTime(2019, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), true, new DateTimeOffset(new DateTime(2020, 4, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Anonymous" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
