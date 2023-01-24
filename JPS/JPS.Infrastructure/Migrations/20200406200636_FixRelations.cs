using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class FixRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionAnswers_Answers_Id",
                table: "OptionAnswers");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "OptionAnswers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OptionAnswers_AnswerId",
                table: "OptionAnswers",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionAnswers_Answers_AnswerId",
                table: "OptionAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionAnswers_Answers_AnswerId",
                table: "OptionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_OptionAnswers_AnswerId",
                table: "OptionAnswers");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "OptionAnswers");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionAnswers_Answers_Id",
                table: "OptionAnswers",
                column: "Id",
                principalTable: "Answers",
                principalColumn: "Id");
        }
    }
}
