using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterStorageApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitiativeBonusadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InitiativeBonus",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitiativeBonus",
                table: "Character");
        }
    }
}
