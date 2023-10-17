using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JusiLms.Migrations
{
    /// <inheritdoc />
    public partial class CategoryToHomeworks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "HomeWorks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_CategoryId",
                table: "HomeWorks",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_Categories_CategoryId",
                table: "HomeWorks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_Categories_CategoryId",
                table: "HomeWorks");

            migrationBuilder.DropIndex(
                name: "IX_HomeWorks_CategoryId",
                table: "HomeWorks");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "HomeWorks");
        }
    }
}
