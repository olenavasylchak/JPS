using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class SeedSecondUserAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "QuestionId", "UserId" },
                values: new object[,]
                {
                    { 45, 12, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 64, 31, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 63, 30, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 62, 29, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 61, 28, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 60, 27, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 59, 26, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 58, 25, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 57, 24, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 56, 23, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 55, 22, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 54, 21, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 53, 20, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 52, 19, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 51, 18, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 50, 17, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 49, 16, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 48, 15, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 47, 14, "438d3c8d-0a2e-4112-a9ea-96e3de436595" },
                    { 46, 13, "438d3c8d-0a2e-4112-a9ea-96e3de436595" }
                });

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

            migrationBuilder.InsertData(
                table: "DateAnswers",
                columns: new[] { "AnswerId", "Date" },
                values: new object[,]
                {
                    { 54, new DateTimeOffset(new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 64, new DateTimeOffset(new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OptionAnswers",
                columns: new[] { "Id", "AnswerId", "OptionId", "OptionRowId" },
                values: new object[,]
                {
                    { 36, 47, 15, null },
                    { 48, 62, 57, 13 },
                    { 44, 61, 54, null },
                    { 54, 63, 59, 16 },
                    { 42, 59, 45, null },
                    { 39, 58, 43, null },
                    { 37, 57, 39, null },
                    { 56, 63, 60, 18 },
                    { 49, 62, 56, 14 },
                    { 52, 53, 35, 11 },
                    { 53, 53, 34, 12 },
                    { 47, 52, 32, 9 },
                    { 46, 52, 33, 8 },
                    { 45, 52, 32, 7 },
                    { 43, 51, 29, null },
                    { 55, 63, 59, 17 },
                    { 41, 49, 24, null },
                    { 40, 48, 43, null },
                    { 38, 48, 20, null },
                    { 51, 53, 35, 10 },
                    { 50, 62, 56, 15 }
                });

            migrationBuilder.InsertData(
                table: "ParagraphAnswers",
                columns: new[] { "AnswerId", "Text" },
                values: new object[,]
                {
                    { 46, "Опора в житті." },
                    { 56, "колектив, який завжди готовий допомогти." }
                });

            migrationBuilder.InsertData(
                table: "TextAnswers",
                columns: new[] { "AnswerId", "Text" },
                values: new object[,]
                {
                    { 55, "Важко сказати." },
                    { 45, "Я б хотів збільшити вологість в офісі." }
                });

            migrationBuilder.InsertData(
                table: "TimeAnswers",
                columns: new[] { "AnswerId", "Time" },
                values: new object[,]
                {
                    { 60, new TimeSpan(0, 16, 0, 0, 0) },
                    { 50, new TimeSpan(0, 12, 0, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DateAnswers",
                keyColumn: "AnswerId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "DateAnswers",
                keyColumn: "AnswerId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ParagraphAnswers",
                keyColumn: "AnswerId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ParagraphAnswers",
                keyColumn: "AnswerId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TextAnswers",
                keyColumn: "AnswerId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TextAnswers",
                keyColumn: "AnswerId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TimeAnswers",
                keyColumn: "AnswerId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TimeAnswers",
                keyColumn: "AnswerId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 64);

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
