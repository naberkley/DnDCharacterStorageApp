using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterStorageApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SkillsAndAbilitiesRedo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Initiative",
                table: "Character");

            migrationBuilder.AddColumn<string>(
                name: "SkillAbility",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Alignment",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "Abilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillAbility",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "Abilities");

            migrationBuilder.AddColumn<int>(
                name: "Initiative",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
