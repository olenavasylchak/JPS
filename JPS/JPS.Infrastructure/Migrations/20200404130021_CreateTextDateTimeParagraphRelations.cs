using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class CreateTextDateTimeParagraphRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "TextAnswers",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DateAnswers_Answers_Id",
                table: "DateAnswers",
                column: "Id",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParagraphAnswers_Answers_Id",
                table: "ParagraphAnswers",
                column: "Id",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextAnswers_Answers_Id",
                table: "TextAnswers",
                column: "Id",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAnswers_Answers_Id",
                table: "TimeAnswers",
                column: "Id",
                principalTable: "Answers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateAnswers_Answers_Id",
                table: "DateAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ParagraphAnswers_Answers_Id",
                table: "ParagraphAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TextAnswers_Answers_Id",
                table: "TextAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeAnswers_Answers_Id",
                table: "TimeAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "TextAnswers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250);
        }
    }
}
