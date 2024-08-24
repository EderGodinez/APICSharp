using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class tets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OriginalTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Overview = table.Column<string>(type: "varchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PosterImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TrailerLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WatchLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AddedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    TypeMedia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RelaseDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    AgeRate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosterImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeMedia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgeRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("CK_User_Role", "[Role] IN ('admin', 'user')");
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Media_Id",
                        column: x => x.Id,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GendersList",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    SerieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GendersList", x => new { x.MediaId, x.GenderId });
                    table.ForeignKey(
                        name: "FK_GendersList_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GendersList_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GendersList_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MediaAvailibleIn",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    SerieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaAvailibleIn", x => new { x.MediaId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_MediaAvailibleIn_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaAvailibleIn_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaAvailibleIn_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieId = table.Column<int>(type: "int", nullable: false),
                    NumSeason = table.Column<byte>(type: "tinyint", nullable: false),
                    DateRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerieId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_Season_Media_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Season_Series_SerieId1",
                        column: x => x.SerieId1,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<byte>(type: "tinyint", nullable: false),
                    RateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => new { x.UserId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_Ratings_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserActions",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    TypeAction = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActions", x => new { x.UserId, x.MediaId, x.TypeAction });
                    table.ForeignKey(
                        name: "FK_UserActions_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E_Num = table.Column<byte>(type: "tinyint", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AddedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    WatchLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RelaseDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episode_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeList",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    SeasonId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeList", x => new { x.SeasonId, x.EpisodeId });
                    table.ForeignKey(
                        name: "FK_EpisodeList_Episode_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeList_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeList_Season_SeasonId1",
                        column: x => x.SeasonId1,
                        principalTable: "Season",
                        principalColumn: "SeasonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_SeasonId",
                table: "Episode",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeList_EpisodeId",
                table: "EpisodeList",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeList_SeasonId1",
                table: "EpisodeList",
                column: "SeasonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_Name",
                table: "Genders",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GendersList_GenderId",
                table: "GendersList",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GendersList_SerieId",
                table: "GendersList",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaAvailibleIn_PlatformId",
                table: "MediaAvailibleIn",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaAvailibleIn_SerieId",
                table: "MediaAvailibleIn",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_Name",
                table: "Platforms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MediaId",
                table: "Ratings",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SerieId",
                table: "Ratings",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Season_SerieId",
                table: "Season",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActions_MediaId",
                table: "UserActions",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeList");

            migrationBuilder.DropTable(
                name: "GendersList");

            migrationBuilder.DropTable(
                name: "MediaAvailibleIn");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UserActions");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
