using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class RenameKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateAnswers_Answers_Id",
                table: "DateAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_FileAnswers_Answers_Id",
                table: "FileAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ParagraphAnswers_Answers_Id",
                table: "ParagraphAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TextAnswers_Answers_Id",
                table: "TextAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeAnswers_Answers_Id",
                table: "TimeAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeAnswers",
                table: "TimeAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TextAnswers",
                table: "TextAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParagraphAnswers",
                table: "ParagraphAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileAnswers",
                table: "FileAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DateAnswers",
                table: "DateAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TimeAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TextAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ParagraphAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FileAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DateAnswers");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "TimeAnswers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "TextAnswers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "ParagraphAnswers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "FileAnswers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "DateAnswers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeAnswers",
                table: "TimeAnswers",
                column: "AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextAnswers",
                table: "TextAnswers",
                column: "AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParagraphAnswers",
                table: "ParagraphAnswers",
                column: "AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileAnswers",
                table: "FileAnswers",
                column: "AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DateAnswers",
                table: "DateAnswers",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DateAnswers_Answers_AnswerId",
                table: "DateAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAnswers_Answers_AnswerId",
                table: "FileAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParagraphAnswers_Answers_AnswerId",
                table: "ParagraphAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextAnswers_Answers_AnswerId",
                table: "TextAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAnswers_Answers_AnswerId",
                table: "TimeAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateAnswers_Answers_AnswerId",
                table: "DateAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_FileAnswers_Answers_AnswerId",
                table: "FileAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ParagraphAnswers_Answers_AnswerId",
                table: "ParagraphAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TextAnswers_Answers_AnswerId",
                table: "TextAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeAnswers_Answers_AnswerId",
                table: "TimeAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeAnswers",
                table: "TimeAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TextAnswers",
                table: "TextAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParagraphAnswers",
                table: "ParagraphAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileAnswers",
                table: "FileAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DateAnswers",
                table: "DateAnswers");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "TimeAnswers");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "TextAnswers");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "ParagraphAnswers");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "FileAnswers");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "DateAnswers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TimeAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TextAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ParagraphAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FileAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DateAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeAnswers",
                table: "TimeAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextAnswers",
                table: "TextAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParagraphAnswers",
                table: "ParagraphAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileAnswers",
                table: "FileAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DateAnswers",
                table: "DateAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DateAnswers_Answers_Id",
                table: "DateAnswers",
                column: "Id",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAnswers_Answers_Id",
                table: "FileAnswers",
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
    }
}
