using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JusiLms.Migrations
{
    /// <inheritdoc />
    public partial class MoreDetailsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Insta",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tg",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wa",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Insta",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Tg",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Wa",
                table: "AspNetUsers");
        }
    }
}
