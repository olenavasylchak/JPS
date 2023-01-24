using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class AddJobIdsToPoll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndPollJobId",
                table: "Polls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InProgressPollJobId",
                table: "Polls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartPollJobId",
                table: "Polls",
                nullable: true);

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
            migrationBuilder.DropColumn(
                name: "EndPollJobId",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "InProgressPollJobId",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "StartPollJobId",
                table: "Polls");

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
