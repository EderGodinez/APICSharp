using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixSeasonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Season");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRelease",
                table: "Season",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "Num_Season",
                table: "Season",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Season",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Season_SerieId",
                table: "Season",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Media_SerieId",
                table: "Season",
                column: "SerieId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Season_Media_SerieId",
                table: "Season");

            migrationBuilder.DropIndex(
                name: "IX_Season_SerieId",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "DateRelease",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "Num_Season",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Season");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Season",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
