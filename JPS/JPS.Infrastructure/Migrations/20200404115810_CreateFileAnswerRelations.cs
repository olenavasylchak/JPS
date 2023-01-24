using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class CreateFileAnswerRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FileAnswers_FileId",
                table: "FileAnswers",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAnswers_Files_FileId",
                table: "FileAnswers",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAnswers_Files_FileId",
                table: "FileAnswers");

            migrationBuilder.DropIndex(
                name: "IX_FileAnswers_FileId",
                table: "FileAnswers");
        }
    }
}
