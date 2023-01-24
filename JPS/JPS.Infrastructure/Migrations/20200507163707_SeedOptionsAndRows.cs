using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class SeedOptionsAndRows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OptionRows",
                columns: new[] { "Id", "ImageId", "Order", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 10, null, 1, 20, "Задоволений" },
                    { 18, null, 3, 30, "Не задоволений" },
                    { 17, null, 2, 30, "Важко сказати" },
                    { 16, null, 1, 30, "Задоволений" },
                    { 15, null, 3, 29, "Дружність" },
                    { 14, null, 2, 29, "Взаємодопомого" },
                    { 13, null, 1, 29, "Атмосфера" },
                    { 12, null, 3, 20, "Не задоволений" },
                    { 11, null, 2, 20, "Важко сказати" },
                    { 9, null, 3, 19, "Освітлення" },
                    { 8, null, 2, 19, "Вентиляція" },
                    { 7, null, 1, 19, "Температура" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "ImageId", "Order", "QuestionId", "Text", "Value" },
                values: new object[,]
                {
                    { 50, null, 1, 28, null, 1m },
                    { 49, null, 5, 26, "Не згоден", null },
                    { 48, null, 4, 26, "Не зовсім згоден", null },
                    { 13, null, 1, 14, "Згоден", null },
                    { 46, null, 2, 26, "В прицнипі згоден", null },
                    { 51, null, 2, 28, null, 2m },
                    { 47, null, 3, 26, "Важко сказати, не можу визначитись", null },
                    { 52, null, 3, 28, null, 3m },
                    { 59, null, 2, 30, "Зарплата", null },
                    { 54, null, 5, 28, null, 5m },
                    { 55, null, 1, 29, "Добре", null },
                    { 56, null, 2, 29, "Нормально", null },
                    { 57, null, 3, 29, "Погано", null },
                    { 58, null, 1, 30, "Умови", null },
                    { 45, null, 1, 26, "Згоден", null },
                    { 60, null, 3, 30, "Менеджмент", null },
                    { 53, null, 4, 28, null, 4m },
                    { 44, null, 3, 25, "Чвсу", null },
                    { 43, null, 2, 25, "Свободи дій", null },
                    { 42, null, 1, 25, "Мотивації", null },
                    { 14, null, 2, 14, "В прицнипі згоден", null },
                    { 15, null, 3, 14, "Важко сказати, не можу визначитись", null },
                    { 16, null, 4, 14, "Не зовсім згоден", null },
                    { 17, null, 5, 14, "Не згоден", null },
                    { 18, null, 1, 15, "Чистота", null },
                    { 19, null, 2, 15, "Менеджмент", null },
                    { 20, null, 3, 15, "Матеріальна компенсація", null },
                    { 21, null, 1, 16, "Згоден", null },
                    { 22, null, 2, 16, "В прицнипі згоден", null },
                    { 23, null, 3, 16, "Важко сказати, не можу визначитись", null },
                    { 24, null, 4, 16, "Не зовсім згоден", null },
                    { 25, null, 5, 16, "Не згоден", null },
                    { 26, null, 1, 18, null, 1m },
                    { 27, null, 2, 18, null, 2m },
                    { 29, null, 4, 18, null, 4m },
                    { 30, null, 5, 18, null, 5m },
                    { 31, null, 1, 19, "Добре", null },
                    { 32, null, 2, 19, "Нормально", null },
                    { 33, null, 3, 19, "Погано", null },
                    { 34, null, 1, 20, "Умови", null },
                    { 35, null, 2, 20, "Зарплата", null },
                    { 36, null, 3, 20, "Менеджмент", null },
                    { 37, null, 1, 24, "Згоден", null },
                    { 38, null, 2, 24, "В прицнипі згоден", null },
                    { 39, null, 3, 24, "Важко сказати, не можу визначитись", null },
                    { 40, null, 4, 24, "Не зовсім згоден", null },
                    { 41, null, 5, 24, "Не згоден", null },
                    { 28, null, 3, 18, null, 3m }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OptionRows",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 60);

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
