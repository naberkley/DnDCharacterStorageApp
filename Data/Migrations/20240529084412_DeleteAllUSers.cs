using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterStorageApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAllUSers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
