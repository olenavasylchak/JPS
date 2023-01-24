using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class SetOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CanHaveOtherOption",
                value: true);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CanHaveOtherOption",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CanHaveOtherOption",
                value: true);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CanHaveOtherOption",
                value: true);
        }
    }
}
