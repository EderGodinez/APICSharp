using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class MovieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Media_MediaId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_MediaId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Movie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MediaId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_MediaId",
                table: "Movie",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Media_MediaId",
                table: "Movie",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
