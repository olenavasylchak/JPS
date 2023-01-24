using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class SeedThirdUserAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "QuestionId", "UserId" },
                values: new object[,]
                {
                    { 65, 12, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 84, 31, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 83, 30, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 82, 29, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 81, 28, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 80, 27, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 79, 26, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 78, 25, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 77, 24, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 76, 23, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 75, 22, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 74, 21, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 73, 20, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 72, 19, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 71, 18, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 70, 17, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 69, 16, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 68, 15, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 67, 14, "1fea2f55-ea63-472d-a71c-74336c54273c" },
                    { 66, 13, "1fea2f55-ea63-472d-a71c-74336c54273c" }
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
                    { 84, new DateTimeOffset(new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 74, new DateTimeOffset(new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OptionAnswers",
                columns: new[] { "Id", "AnswerId", "OptionId", "OptionRowId" },
                values: new object[,]
                {
                    { 76, 83, 59, 17 },
                    { 75, 83, 59, 16 },
                    { 71, 82, 55, 15 },
                    { 70, 82, 55, 14 },
                    { 69, 82, 56, 13 },
                    { 65, 81, 52, null },
                    { 63, 79, 45, null },
                    { 60, 78, 44, null },
                    { 58, 77, 37, null },
                    { 77, 83, 60, 18 },
                    { 74, 73, 34, 12 },
                    { 72, 73, 35, 10 },
                    { 68, 72, 31, 9 },
                    { 67, 72, 31, 8 },
                    { 66, 72, 32, 7 },
                    { 64, 71, 30, null },
                    { 62, 69, 22, null },
                    { 61, 68, 43, null },
                    { 59, 68, 19, null },
                    { 57, 67, 17, null },
                    { 73, 73, 35, 11 }
                });

            migrationBuilder.InsertData(
                table: "ParagraphAnswers",
                columns: new[] { "AnswerId", "Text" },
                values: new object[,]
                {
                    { 76, "друга сім'я." },
                    { 66, "Стимул розвиватися." }
                });

            migrationBuilder.InsertData(
                table: "TextAnswers",
                columns: new[] { "AnswerId", "Text" },
                values: new object[] { 65, "У мене немає побажань." });

            migrationBuilder.InsertData(
                table: "TimeAnswers",
                columns: new[] { "AnswerId", "Time" },
                values: new object[,]
                {
                    { 80, new TimeSpan(0, 15, 0, 0, 0) },
                    { 70, new TimeSpan(0, 10, 0, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "DateAnswers",
                keyColumn: "AnswerId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "DateAnswers",
                keyColumn: "AnswerId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ParagraphAnswers",
                keyColumn: "AnswerId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ParagraphAnswers",
                keyColumn: "AnswerId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "TextAnswers",
                keyColumn: "AnswerId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TimeAnswers",
                keyColumn: "AnswerId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "TimeAnswers",
                keyColumn: "AnswerId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 84);

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
