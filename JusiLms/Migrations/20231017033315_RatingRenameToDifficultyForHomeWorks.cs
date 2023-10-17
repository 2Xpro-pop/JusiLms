using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JusiLms.Migrations
{
    /// <inheritdoc />
    public partial class RatingRenameToDifficultyForHomeWorks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "HomeWorks",
                newName: "Difficulty");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Difficulty",
                table: "HomeWorks",
                newName: "Rating");
        }
    }
}
