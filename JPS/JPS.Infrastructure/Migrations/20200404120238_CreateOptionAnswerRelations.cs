using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class CreateOptionAnswerRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OptionAnswers_OptionId",
                table: "OptionAnswers",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionAnswers_OptionRowId",
                table: "OptionAnswers",
                column: "OptionRowId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAnswers_Answers_Id",
                table: "FileAnswers",
                column: "Id",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionAnswers_Answers_Id",
                table: "OptionAnswers",
                column: "Id",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionAnswers_Options_OptionId",
                table: "OptionAnswers",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionAnswers_OptionRows_OptionRowId",
                table: "OptionAnswers",
                column: "OptionRowId",
                principalTable: "OptionRows",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAnswers_Answers_Id",
                table: "FileAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionAnswers_Answers_Id",
                table: "OptionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionAnswers_Options_OptionId",
                table: "OptionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionAnswers_OptionRows_OptionRowId",
                table: "OptionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_OptionAnswers_OptionId",
                table: "OptionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_OptionAnswers_OptionRowId",
                table: "OptionAnswers");
        }
    }
}
