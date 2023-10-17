using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JusiLms.Migrations
{
    /// <inheritdoc />
    public partial class TimeStampAddedForHomeWorks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HomeWorks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "HomeWorks",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HomeWorks");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "HomeWorks");
        }
    }
}
