using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Season_SeasonId",
                table: "Episode");

            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeList_Season_SeasonId",
                table: "EpisodeList");

            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeList_Season_SeasonId1",
                table: "EpisodeList");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Media_SerieId",
                table: "Season");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Series_SerieId1",
                table: "Season");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Season",
                table: "Season");

            migrationBuilder.DropIndex(
                name: "IX_Season_SerieId1",
                table: "Season");

            migrationBuilder.DropIndex(
                name: "IX_EpisodeList_SeasonId1",
                table: "EpisodeList");

            migrationBuilder.DropIndex(
                name: "IX_Episode_SeasonId",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "DateRelease",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "NumSeason",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "SeasonId1",
                table: "EpisodeList");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Episode");

            migrationBuilder.RenameColumn(
                name: "SerieId1",
                table: "Season",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "SerieId",
                table: "Season",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Season",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Season",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Season",
                table: "Season",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeList_Season_SeasonId",
                table: "EpisodeList",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Series_SerieId",
                table: "Season",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EpisodeList_Season_SeasonId",
                table: "EpisodeList");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Series_SerieId",
                table: "Season");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Season",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Season");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Season",
                newName: "SerieId1");

            migrationBuilder.AlterColumn<int>(
                name: "SerieId",
                table: "Season",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SerieId1",
                table: "Season",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Season",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRelease",
                table: "Season",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "NumSeason",
                table: "Season",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);


            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Episode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Season",
                table: "Season",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Season_SerieId1",
                table: "Season",
                column: "SerieId1");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeList_SeasonId1",
                table: "EpisodeList",
                column: "SeasonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Episode_SeasonId",
                table: "Episode",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Season_SeasonId",
                table: "Episode",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EpisodeList_Season_SeasonId",
                table: "EpisodeList",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Media_SerieId",
                table: "Season",
                column: "SerieId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Series_SerieId1",
                table: "Season",
                column: "SerieId1",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
