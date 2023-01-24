using Microsoft.EntityFrameworkCore.Migrations;

namespace JPS.Domain.Entities.Migrations
{
    public partial class DeleteFileTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAnswers_Files_FileId",
                table: "FileAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionRows_Images_ImageId",
                table: "OptionRows");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Images_ImageId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Images_ImageId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Videos_VideoId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ImageId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_VideoId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Options_ImageId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_OptionRows_ImageId",
                table: "OptionRows");

            migrationBuilder.DropIndex(
                name: "IX_FileAnswers_FileId",
                table: "FileAnswers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "OptionRows");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "FileAnswers");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Options",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "OptionRows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "FileAnswers",
                nullable: false,
                defaultValue: "");

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
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "OptionRows");

            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "FileAnswers");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Options",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "OptionRows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "FileAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Files",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9
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

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ImageId",
                table: "Questions",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_VideoId",
                table: "Questions",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ImageId",
                table: "Options",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionRows_ImageId",
                table: "OptionRows",
                column: "ImageId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OptionRows_Images_ImageId",
                table: "OptionRows",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Images_ImageId",
                table: "Options",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Images_ImageId",
                table: "Questions",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Videos_VideoId",
                table: "Questions",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
