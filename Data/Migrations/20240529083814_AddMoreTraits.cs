using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterStorageApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreTraits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CharacterName",
                table: "Character",
                newName: "Race");

            migrationBuilder.RenameColumn(
                name: "CharacterClass",
                table: "Character",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Initiative",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Background",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Initiative",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "Race",
                table: "Character",
                newName: "CharacterName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Character",
                newName: "CharacterClass");
        }
    }
}
