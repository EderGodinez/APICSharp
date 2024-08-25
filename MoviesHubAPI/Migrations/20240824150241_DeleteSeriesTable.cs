using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSeriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GendersList_Series_SerieId",
                table: "GendersList");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaAvailibleIn_Series_SerieId",
                table: "MediaAvailibleIn");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Series_SerieId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Series_SerieId",
                table: "Season");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Season_SerieId",
                table: "Season");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_SerieId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_MediaAvailibleIn_SerieId",
                table: "MediaAvailibleIn");

            migrationBuilder.DropIndex(
                name: "IX_GendersList_SerieId",
                table: "GendersList");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "MediaAvailibleIn");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "GendersList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Season",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Ratings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "MediaAvailibleIn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "GendersList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgeRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosterImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeMedia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Season_SerieId",
                table: "Season",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SerieId",
                table: "Ratings",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaAvailibleIn_SerieId",
                table: "MediaAvailibleIn",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_GendersList_SerieId",
                table: "GendersList",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_GendersList_Series_SerieId",
                table: "GendersList",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaAvailibleIn_Series_SerieId",
                table: "MediaAvailibleIn",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Series_SerieId",
                table: "Ratings",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Series_SerieId",
                table: "Season",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");
        }
    }
}
