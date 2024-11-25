using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomowaBiblioteczka.Migrations.MediaDb
{
    /// <inheritdoc />
    public partial class Imroveschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeOrPages",
                table: "Medias",
                newName: "Length");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "MediaTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IndustryID",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Symbole = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaTypes_UnitId",
                table: "MediaTypes",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_IndustryID",
                table: "Medias",
                column: "IndustryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Industries_IndustryID",
                table: "Medias",
                column: "IndustryID",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaTypes_Units_UnitId",
                table: "MediaTypes",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Industries_IndustryID",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaTypes_Units_UnitId",
                table: "MediaTypes");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_MediaTypes_UnitId",
                table: "MediaTypes");

            migrationBuilder.DropIndex(
                name: "IX_Medias_IndustryID",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "MediaTypes");

            migrationBuilder.DropColumn(
                name: "IndustryID",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Medias",
                newName: "TimeOrPages");
        }
    }
}
