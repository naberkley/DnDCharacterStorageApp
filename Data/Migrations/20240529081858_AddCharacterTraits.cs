using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterStorageApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterTraits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_AspNetUsers_CreatedById",
                table: "Character");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Character",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ArmorClass",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Charisma",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Constitution",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dexterity",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HitPoints",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Intelligence",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wisdom",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_AspNetUsers_CreatedById",
                table: "Character",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_AspNetUsers_CreatedById",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "ArmorClass",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Charisma",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Constitution",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Dexterity",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "HitPoints",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Intelligence",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Strength",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Wisdom",
                table: "Character");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Character",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_AspNetUsers_CreatedById",
                table: "Character",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
