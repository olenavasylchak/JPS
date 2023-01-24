using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class InitializeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ParentCategoryId", "Title" },
                values: new object[] { 1, null, "JSPSurvey" });

            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 11, "Time" },
                    { 10, "Date" },
                    { 9, "Checkbox grid" },
                    { 7, "Linear scale" },
                    { 6, "File upload" },
                    { 8, "Multiple choice grid" },
                    { 4, "Checkboxes" },
                    { 3, "Multiple choice" },
                    { 2, "Paragraph" },
                    { 1, "Text" },
                    { 5, "Dropdown" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                column: "Id",
                values: new object[]
                {
                    "7ad340b8-5610-4aef-9531-808dd8befa06",
                    "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2",
                    "5fc39df2-aea1-405d-b887-b7167fb3d60b",
                    "39be8196-adbd-405e-a4ed-9025abdaaec7",
                    "e661b6a9-aa0d-44e2-9013-a267dfed12ef"
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ParentCategoryId", "Title" },
                values: new object[] { 2, 1, "ESAT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "39be8196-adbd-405e-a4ed-9025abdaaec7");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5fc39df2-aea1-405d-b887-b7167fb3d60b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6b4b7339-1f6c-41bc-885f-3eee80d2f7c2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7ad340b8-5610-4aef-9531-808dd8befa06");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e661b6a9-aa0d-44e2-9013-a267dfed12ef");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
