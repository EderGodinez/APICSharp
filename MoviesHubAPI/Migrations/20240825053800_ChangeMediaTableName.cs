using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMediaTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenderLists_Series_MediaId",
                table: "GenderLists");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaAvailibleIn_Series_MediaId",
                table: "MediaAvailibleIn");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Series_MediaId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Series_MediaId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActions_Series_MediaId",
                table: "UserActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Series",
                table: "Series");

            migrationBuilder.RenameTable(
                name: "Series",
                newName: "Media");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenderLists_Media_MediaId",
                table: "GenderLists",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaAvailibleIn_Media_MediaId",
                table: "MediaAvailibleIn",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Media_MediaId",
                table: "Movies",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Media_MediaId",
                table: "Ratings",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Media_SerieId",
                table: "Seasons",
                column: "SerieId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActions_Media_MediaId",
                table: "UserActions",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenderLists_Media_MediaId",
                table: "GenderLists");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaAvailibleIn_Media_MediaId",
                table: "MediaAvailibleIn");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Media_MediaId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Media_MediaId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Media_SerieId",
                table: "Seasons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActions_Media_MediaId",
                table: "UserActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Series");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Series",
                table: "Series",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenderLists_Series_MediaId",
                table: "GenderLists",
                column: "MediaId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaAvailibleIn_Series_MediaId",
                table: "MediaAvailibleIn",
                column: "MediaId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Series_MediaId",
                table: "Movies",
                column: "MediaId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Series_MediaId",
                table: "Ratings",
                column: "MediaId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActions_Series_MediaId",
                table: "UserActions",
                column: "MediaId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
