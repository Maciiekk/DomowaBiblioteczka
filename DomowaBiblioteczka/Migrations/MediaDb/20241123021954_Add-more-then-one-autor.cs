using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomowaBiblioteczka.Migrations.MediaDb
{
    /// <inheritdoc />
    public partial class Addmorethenoneautor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Authors_AuthorId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_AuthorId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Medias");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Medias",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "MediaAuthors",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    MediasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaAuthors", x => new { x.AuthorsId, x.MediasId });
                    table.ForeignKey(
                        name: "FK_MediaAuthors_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaAuthors_Medias_MediasId",
                        column: x => x.MediasId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaAuthors_MediasId",
                table: "MediaAuthors",
                column: "MediasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaAuthors");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Medias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_AuthorId",
                table: "Medias",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Authors_AuthorId",
                table: "Medias",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
