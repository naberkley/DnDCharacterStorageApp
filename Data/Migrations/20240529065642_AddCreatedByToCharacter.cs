using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterStorageApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByToCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Character",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Character_CreatedById",
                table: "Character",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_AspNetUsers_CreatedById",
                table: "Character",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_AspNetUsers_CreatedById",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_CreatedById",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Character");
        }
    }
}
