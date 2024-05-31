using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterStorageApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AbilitySkillsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ability_Character_CharacterId",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Character_CharacterId",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ability",
                table: "Ability");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "Ability",
                newName: "Abilities");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_CharacterId",
                table: "Skills",
                newName: "IX_Skills_CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Ability_CharacterId",
                table: "Abilities",
                newName: "IX_Abilities_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abilities",
                table: "Abilities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Character_CharacterId",
                table: "Abilities",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Character_CharacterId",
                table: "Skills",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Character_CharacterId",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Character_CharacterId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abilities",
                table: "Abilities");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "Abilities",
                newName: "Ability");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_CharacterId",
                table: "Skill",
                newName: "IX_Skill_CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Abilities_CharacterId",
                table: "Ability",
                newName: "IX_Ability_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ability",
                table: "Ability",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_Character_CharacterId",
                table: "Ability",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Character_CharacterId",
                table: "Skill",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
