using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class SeedFirstUserAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "QuestionId", "UserId" },
                values: new object[,]
                {
                    { 25, 12, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 44, 31, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 43, 30, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 42, 29, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 41, 28, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 40, 27, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 39, 26, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 38, 25, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 37, 24, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 36, 23, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 35, 22, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 34, 21, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 33, 20, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 32, 19, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 31, 18, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 30, 17, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 29, 16, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 28, 15, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 27, 14, "d895b083-82af-47d9-8ff7-abdc9bf862da" },
                    { 26, 13, "d895b083-82af-47d9-8ff7-abdc9bf862da" }
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
                    { 44, new DateTimeOffset(new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 34, new DateTimeOffset(new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OptionAnswers",
                columns: new[] { "Id", "AnswerId", "OptionId", "OptionRowId" },
                values: new object[,]
                {
                    { 27, 42, 57, 13 },
                    { 23, 41, 54, null },
                    { 33, 43, 58, 16 },
                    { 21, 39, 46, null },
                    { 19, 38, 43, null },
                    { 18, 38, 42, null },
                    { 16, 37, 38, null },
                    { 35, 43, 60, 18 },
                    { 28, 42, 55, 14 },
                    { 32, 33, 36, 12 },
                    { 30, 33, 34, 10 },
                    { 26, 32, 32, 9 },
                    { 25, 32, 31, 8 },
                    { 24, 32, 31, 7 },
                    { 22, 31, 29, null },
                    { 34, 43, 58, 17 },
                    { 20, 29, 22, null },
                    { 17, 28, 19, null },
                    { 15, 27, 13, null },
                    { 31, 33, 35, 11 },
                    { 29, 42, 55, 14 }
                });

            migrationBuilder.InsertData(
                table: "ParagraphAnswers",
                columns: new[] { "AnswerId", "Text" },
                values: new object[,]
                {
                    { 36, "Мої друзі" },
                    { 26, "Гарантія стабільності" }
                });

            migrationBuilder.InsertData(
                table: "TextAnswers",
                columns: new[] { "AnswerId", "Text" },
                values: new object[,]
                {
                    { 35, "Мене все влаштовує." },
                    { 25, "Я б хотів збільшити температуру в офісі." }
                });

            migrationBuilder.InsertData(
                table: "TimeAnswers",
                columns: new[] { "AnswerId", "Time" },
                values: new object[,]
                {
                    { 40, new TimeSpan(0, 16, 0, 0, 0) },
                    { 30, new TimeSpan(0, 12, 0, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DateAnswers",
                keyColumn: "AnswerId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "DateAnswers",
                keyColumn: "AnswerId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ParagraphAnswers",
                keyColumn: "AnswerId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ParagraphAnswers",
                keyColumn: "AnswerId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TextAnswers",
                keyColumn: "AnswerId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TextAnswers",
                keyColumn: "AnswerId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TimeAnswers",
                keyColumn: "AnswerId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TimeAnswers",
                keyColumn: "AnswerId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 44);

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
