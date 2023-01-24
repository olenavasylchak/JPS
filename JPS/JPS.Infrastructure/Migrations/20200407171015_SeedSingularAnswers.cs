using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class SeedSingularAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "QuestionId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 22, 11, "39be8196-adbd-405e-a4ed-9025abdaaec7" },
                    { 21, 10, "39be8196-adbd-405e-a4ed-9025abdaaec7" },
                    { 20, 9, "39be8196-adbd-405e-a4ed-9025abdaaec7" },
                    { 19, 8, "39be8196-adbd-405e-a4ed-9025abdaaec7" },
                    { 18, 7, "39be8196-adbd-405e-a4ed-9025abdaaec7" },
                    { 17, 6, "39be8196-adbd-405e-a4ed-9025abdaaec7" },
                    { 16, 5, "39be8196-adbd-405e-a4ed-9025abdaaec7" },
                    { 15, 4, "39be8196-adbd-405e-a4ed-9025abdaaec7" },
                    { 14, 3, "39be8196-adbd-405e-a4ed-9025abdaaec7" },
                    { 13, 2, "39be8196-adbd-405e-a4ed-9025abdaaec7" },
                    { 12, 1, "39be8196-adbd-405e-a4ed-9025abdaaec7" },
                    { 11, 11, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 10, 10, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 9, 9, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 8, 8, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 7, 7, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 6, 6, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 5, 5, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 4, 4, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 3, 3, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 2, 2, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 23, 2, "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2" },
                    { 24, 9, "39be8196-adbd-405e-a4ed-9025abdaaec7" }
                });

            migrationBuilder.InsertData(
                table: "DateAnswers",
                columns: new[] { "AnswerId", "Date" },
                values: new object[,]
                {
                    { 5, new DateTimeOffset(new DateTime(1995, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) },
                    { 16, new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ParagraphAnswers",
                columns: new[] { "AnswerId", "Text" },
                values: new object[,]
                {
                    { 10, "Paragraph answer here" },
                    { 21, "Paragraph answer here" }
                });

            migrationBuilder.InsertData(
                table: "TextAnswers",
                columns: new[] { "AnswerId", "Text" },
                values: new object[,]
                {
                    { 6, "Something" },
                    { 17, "Something 2" }
                });

            migrationBuilder.InsertData(
                table: "TimeAnswers",
                columns: new[] { "AnswerId", "Time" },
                values: new object[,]
                {
                    { 11, new TimeSpan(0, 9, 0, 0, 0) },
                    { 22, new TimeSpan(0, 12, 0, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DateAnswers",
                keyColumn: "AnswerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DateAnswers",
                keyColumn: "AnswerId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ParagraphAnswers",
                keyColumn: "AnswerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ParagraphAnswers",
                keyColumn: "AnswerId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TextAnswers",
                keyColumn: "AnswerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TextAnswers",
                keyColumn: "AnswerId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TimeAnswers",
                keyColumn: "AnswerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TimeAnswers",
                keyColumn: "AnswerId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
