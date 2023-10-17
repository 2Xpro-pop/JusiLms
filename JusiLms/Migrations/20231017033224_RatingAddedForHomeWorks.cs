using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JusiLms.Migrations
{
    /// <inheritdoc />
    public partial class RatingAddedForHomeWorks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "HomeWorks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "HomeWorks");
        }
    }
}
