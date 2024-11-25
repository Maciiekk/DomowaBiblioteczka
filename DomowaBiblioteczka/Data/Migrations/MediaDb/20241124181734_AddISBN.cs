using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomowaBiblioteczka.Migrations.MediaDb
{
    /// <inheritdoc />
    public partial class AddISBN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Medias",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Medias");
        }
    }
}
