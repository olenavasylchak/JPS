using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class SeedPollWithQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Polls",
                columns: new[] { "Id", "CategoryId", "Description", "FinishesAt", "IsAnonymous", "StartsAt", "Title" },
                values: new object[] { 4, 1, "Метою даного опитування є потреба розуміти рівень задоволеності кожного працівника роботою в нашій Компанії.", new DateTimeOffset(new DateTime(2020, 7, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), false, new DateTimeOffset(new DateTime(2020, 5, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "ESAT 2020v2" });

            migrationBuilder.InsertData(
                table: "QuestionSections",
                columns: new[] { "Id", "Description", "Order", "PollId", "Title" },
                values: new object[] { 6, "У цій секції будуть міститись питання про компанію.", 1, 4, "Компанія" });

            migrationBuilder.InsertData(
                table: "QuestionSections",
                columns: new[] { "Id", "Description", "Order", "PollId", "Title" },
                values: new object[] { 7, "У цій секції будуть міститись питання про Вашу команду.", 2, 4, "Команда" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Comment", "ImageId", "IsRequired", "Order", "QuestionSectionId", "QuestionTypeId", "Text", "VideoId" },
                values: new object[,]
                {
                    { 12, null, null, true, 1, 6, 1, "Що слід покращити в Компанії?", null },
                    { 29, null, null, true, 8, 7, 8, "Оцініть Вашу команду.", null },
                    { 28, null, null, false, 7, 7, 7, "Атмосфера у команді.", null },
                    { 27, null, null, true, 6, 7, 11, "О котрій годині у Вашої команди Daily call?", null },
                    { 26, null, null, false, 5, 7, 5, "Мій менеджер заохочує співпрацю в команді.", null },
                    { 25, null, null, true, 4, 7, 4, "Чого Вам не вистачає?", null }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CanHaveOtherOption", "Comment", "ImageId", "IsRequired", "Order", "QuestionSectionId", "QuestionTypeId", "Text", "VideoId" },
                values: new object[] { 24, true, null, null, false, 3, 7, 3, "Робота в моїй команді добре координується РМ-ом:", null });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Comment", "ImageId", "IsRequired", "Order", "QuestionSectionId", "QuestionTypeId", "Text", "VideoId" },
                values: new object[,]
                {
                    { 23, null, null, true, 2, 7, 2, "Моя команда для мене - це...    ", null },
                    { 22, null, null, false, 1, 7, 1, "Що слід змінити у Вашій команді?", null },
                    { 21, null, null, false, 10, 6, 10, "Коли б Ви хотіли провести літній корпоратив?", null },
                    { 20, null, null, true, 9, 6, 9, "Зробіть свою оцінку.", null },
                    { 19, null, null, false, 8, 6, 8, "Оцініть офісне приміщення.", null },
                    { 18, null, null, true, 7, 6, 7, "Мені подобається офіс компанії.", null },
                    { 17, null, null, false, 6, 6, 11, "О котрій годині Вам зручно починати працювати?", null },
                    { 16, null, null, true, 5, 6, 5, "Компанія створює умови для кар'єрного зростання.", null }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CanHaveOtherOption", "Comment", "ImageId", "IsRequired", "Order", "QuestionSectionId", "QuestionTypeId", "Text", "VideoId" },
                values: new object[] { 15, true, null, null, false, 4, 6, 4, "Виберіть пункти, які б ви покращили у нашій Компанії.", null });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Comment", "ImageId", "IsRequired", "Order", "QuestionSectionId", "QuestionTypeId", "Text", "VideoId" },
                values: new object[,]
                {
                    { 14, null, null, true, 3, 6, 3, "Компанія надає мені можливості до професійного розвитку.", null },
                    { 13, null, null, false, 2, 6, 2, "Моя компанія для мене - це...", null },
                    { 30, null, null, false, 9, 7, 9, "Заповніть таблицю стосовно Ваших поглядів на команду.", null },
                    { 31, null, null, true, 10, 7, 10, "Оберіть дату для тусовки Вашої команди.", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Polls",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
