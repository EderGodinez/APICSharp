using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class TripleKeyInUserAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserActions",
                table: "UserActions");

            migrationBuilder.AddColumn<int>(
                name: "MediaId",
                table: "Episodes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserActions",
                table: "UserActions",
                columns: new[] { "UserId", "MediaId", "TypeAction" });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_MediaId",
                table: "Episodes",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Media_MediaId",
                table: "Episodes",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Media_MediaId",
                table: "Episodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserActions",
                table: "UserActions");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_MediaId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Episodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserActions",
                table: "UserActions",
                columns: new[] { "UserId", "MediaId" });
        }
    }
}
