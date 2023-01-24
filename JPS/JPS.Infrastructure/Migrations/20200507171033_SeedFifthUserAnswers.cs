using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class SeedFifthUserAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "QuestionId", "UserId" },
                values: new object[,]
                {
                    { 105, 12, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 124, 31, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 123, 30, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 122, 29, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 121, 28, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 120, 27, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 119, 26, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 118, 25, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 117, 24, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 116, 23, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 115, 22, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 114, 21, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 113, 20, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 112, 19, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 111, 18, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 110, 17, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 109, 16, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 108, 15, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 107, 14, "cc115878-58c4-42b3-b384-e780d87bfb02" },
                    { 106, 13, "cc115878-58c4-42b3-b384-e780d87bfb02" }
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
                    { 124, new DateTimeOffset(new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 114, new DateTimeOffset(new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OptionAnswers",
                columns: new[] { "Id", "AnswerId", "OptionId", "OptionRowId" },
                values: new object[,]
                {
                    { 111, 122, 57, 13 },
                    { 107, 121, 54, null },
                    { 117, 123, 58, 16 },
                    { 105, 119, 46, null },
                    { 103, 118, 43, null },
                    { 102, 118, 42, null },
                    { 100, 117, 38, null },
                    { 119, 123, 60, 18 },
                    { 112, 122, 55, 14 },
                    { 116, 113, 36, 12 },
                    { 114, 113, 34, 10 },
                    { 110, 112, 32, 9 },
                    { 109, 112, 31, 8 },
                    { 108, 112, 31, 7 },
                    { 106, 111, 29, null },
                    { 118, 123, 58, 17 },
                    { 104, 109, 22, null },
                    { 101, 108, 19, null },
                    { 99, 107, 13, null },
                    { 115, 113, 35, 11 },
                    { 113, 122, 55, 14 }
                });

            migrationBuilder.InsertData(
                table: "ParagraphAnswers",
                columns: new[] { "AnswerId", "Text" },
                values: new object[,]
                {
                    { 116, "це мої колєги." },
                    { 106, "Прогрес." }
                });

            migrationBuilder.InsertData(
                table: "TextAnswers",
                columns: new[] { "AnswerId", "Text" },
                values: new object[,]
                {
                    { 115, "Все збс." },
                    { 105, "Зремонтуйте стілець." }
                });

            migrationBuilder.InsertData(
                table: "TimeAnswers",
                columns: new[] { "AnswerId", "Time" },
                values: new object[,]
                {
                    { 120, new TimeSpan(0, 16, 0, 0, 0) },
                    { 110, new TimeSpan(0, 12, 0, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DateAnswers",
                keyColumn: "AnswerId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "DateAnswers",
                keyColumn: "AnswerId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "OptionAnswers",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ParagraphAnswers",
                keyColumn: "AnswerId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ParagraphAnswers",
                keyColumn: "AnswerId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "TextAnswers",
                keyColumn: "AnswerId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "TextAnswers",
                keyColumn: "AnswerId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "TimeAnswers",
                keyColumn: "AnswerId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "TimeAnswers",
                keyColumn: "AnswerId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 124);

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
