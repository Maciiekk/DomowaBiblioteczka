using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomowaBiblioteczka.Migrations.MediaDb
{
    /// <inheritdoc />
    public partial class UpdateDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Industries_IndustryTypes_IndustryTypeId",
                table: "Industries");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Authors_AuthorId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_MediaTypes_MediaTypeID",
                table: "Medias");

            migrationBuilder.AddForeignKey(
                name: "FK_Industries_IndustryTypes_IndustryTypeId",
                table: "Industries",
                column: "IndustryTypeId",
                principalTable: "IndustryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Authors_AuthorId",
                table: "Medias",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_MediaTypes_MediaTypeID",
                table: "Medias",
                column: "MediaTypeID",
                principalTable: "MediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Industries_IndustryTypes_IndustryTypeId",
                table: "Industries");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Authors_AuthorId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_MediaTypes_MediaTypeID",
                table: "Medias");

            migrationBuilder.AddForeignKey(
                name: "FK_Industries_IndustryTypes_IndustryTypeId",
                table: "Industries",
                column: "IndustryTypeId",
                principalTable: "IndustryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Authors_AuthorId",
                table: "Medias",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_MediaTypes_MediaTypeID",
                table: "Medias",
                column: "MediaTypeID",
                principalTable: "MediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
