using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class SeedQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuestionSections",
                columns: new[] { "Id", "Description", "Order", "PollId", "Title" },
                values: new object[,]
                {
                    { 1, "Here will be questions about you.", 1, 1, "About you" },
                    { 2, "Here will be questions about you.", 1, 3, "About you" },
                    { 3, "Here will be questions about you.", 1, 2, "About you" },
                    { 4, "Here will be questions about company.", 2, 2, "About company" },
                    { 5, "Here will be questions about team.", 3, 2, "About team" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Comment", "ImageId", "IsRequired", "Order", "QuestionSectionId", "QuestionTypeId", "Text", "VideoId" },
                values: new object[,]
                {
                    { 1, null, null, true, 1, 3, 3, "How are you?", null },
                    { 2, null, null, false, 2, 3, 4, "Why are you crying?", null },
                    { 3, null, null, true, 3, 3, 5, "Choose your sex?", null },
                    { 4, null, null, false, 4, 3, 6, "Download your selfie", null },
                    { 5, null, null, true, 5, 3, 10, "When were you born?", null },
                    { 6, null, null, true, 2, 4, 1, "Short feedback about company", null },
                    { 7, null, null, true, 1, 4, 7, "Are you satisfied with the service in our company?", null },
                    { 8, null, null, true, 3, 4, 8, "Rate our work", null },
                    { 9, null, null, true, 4, 4, 9, "What did you respect in", null },
                    { 10, null, null, true, 1, 5, 2, "What are you think about your team?", null },
                    { 11, null, null, true, 2, 5, 11, "When would you like to come to work?", null }
                });

            migrationBuilder.InsertData(
                table: "OptionRows",
                columns: new[] { "Id", "ImageId", "Order", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 6, null, null, 9, "optionRow 3" },
                    { 4, null, null, 9, "optionRow 1" },
                    { 3, null, null, 8, "optionRow 3" },
                    { 2, null, null, 8, "optionRow 2" },
                    { 1, null, null, 8, "optionRow 1" },
                    { 5, null, null, 9, "optionRow 2" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "ImageId", "Order", "QuestionId", "Text", "Value" },
                values: new object[,]
                {
                    { 12, null, null, 9, "option 2", null },
                    { 11, null, null, 9, "option 1", null },
                    { 10, null, null, 8, "option 2", null },
                    { 9, null, null, 8, "option 1", null },
                    { 7, null, null, 7, "option 1", 1m },
                    { 6, null, null, 3, "option 2", null },
                    { 5, null, null, 3, "option 1", null },
                    { 4, null, 1, 2, "option 2", null },
                    { 3, null, 2, 2, "option 1", null },
                    { 2, null, null, 1, "option 2", null },
                    { 8, null, null, 7, "option 2", 2m },
                    { 1, null, null, 1, "option 1", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
