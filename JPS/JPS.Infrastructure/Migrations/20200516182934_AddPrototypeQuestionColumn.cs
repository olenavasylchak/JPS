using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class AddPrototypeQuestionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrototypeQuestionId",
                table: "Questions",
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

            migrationBuilder.CreateIndex(
                name: "IX_Questions_PrototypeQuestionId",
                table: "Questions",
                column: "PrototypeQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Questions_PrototypeQuestionId",
                table: "Questions",
                column: "PrototypeQuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Questions_PrototypeQuestionId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_PrototypeQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "PrototypeQuestionId",
                table: "Questions");

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
