using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _04_Music_Collection_DB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayLists_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bands_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BandID = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandID",
                        column: x => x.BandID,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Albums_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackPlaylists",
                columns: table => new
                {
                    PlaylistID = table.Column<int>(type: "int", nullable: false),
                    TrackID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackPlaylists", x => new { x.TrackID, x.PlaylistID });
                    table.ForeignKey(
                        name: "FK_TrackPlaylists_PlayLists_PlaylistID",
                        column: x => x.PlaylistID,
                        principalTable: "PlayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackPlaylists_Tracks_TrackID",
                        column: x => x.TrackID,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "The USA" },
                    { 2, "The United Kingdom" },
                    { 3, "Canada" },
                    { 4, "Spain" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hard Rock" },
                    { 2, "Alternative Rock" },
                    { 3, "Pop" },
                    { 4, "Pop Rock" },
                    { 5, "Progressive Rock" },
                    { 6, "Hip Hop" }
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "CountryID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Metallica" },
                    { 2, 1, "Red Hot Chili Peppers" },
                    { 3, 1, "P!nk" },
                    { 4, 1, "Miley Cyrus" },
                    { 5, 1, "Twenty One Pilots" },
                    { 6, 1, "Queen" },
                    { 7, 1, "Eminem" },
                    { 8, 1, "Bon Jovi" },
                    { 9, 1, "Ed Sheeran" },
                    { 10, 1, "Benson Boone" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandID", "GenreID", "Name", "Year" },
                values: new object[,]
                {
                    { 1, 1, 1, "Master of Puppets", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) },
                    { 2, 2, 2, "Californication", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) },
                    { 3, 3, 3, "Beautiful Trauma", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) },
                    { 4, 4, 3, "Bangerz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) },
                    { 5, 5, 2, "Blurryface", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) },
                    { 6, 6, 5, "A Night at the Opera", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) },
                    { 7, 7, 6, "The Eminem Show", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) },
                    { 8, 8, 1, "Slippery When Wet", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) },
                    { 9, 9, 3, "Divide", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) },
                    { 10, 10, 4, "Fireworks & Rollerblades", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "AlbumID", "Duration", "Name" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 0, 5, 13, 0), "Battery" },
                    { 2, 1, new TimeSpan(0, 0, 8, 36, 0), "Master of Puppets" },
                    { 3, 1, new TimeSpan(0, 0, 6, 27, 0), "Welcome Home (Sanitarium)" },
                    { 4, 1, new TimeSpan(0, 0, 8, 16, 0), "Disposable Heroes" },
                    { 5, 1, new TimeSpan(0, 0, 5, 39, 0), "Leper Messiah" },
                    { 6, 1, new TimeSpan(0, 0, 8, 27, 0), "Orion" },
                    { 7, 1, new TimeSpan(0, 0, 5, 32, 0), "Damage, Inc." },
                    { 8, 2, new TimeSpan(0, 0, 3, 58, 0), "Around the World" },
                    { 9, 2, new TimeSpan(0, 0, 4, 30, 0), "Parallel Universe" },
                    { 10, 2, new TimeSpan(0, 0, 3, 37, 0), "Scar Tissue" },
                    { 11, 2, new TimeSpan(0, 0, 4, 15, 0), "Otherside" },
                    { 12, 2, new TimeSpan(0, 0, 3, 18, 0), "Get on Top" },
                    { 13, 2, new TimeSpan(0, 0, 5, 20, 0), "Californication" },
                    { 14, 2, new TimeSpan(0, 0, 3, 51, 0), "Easily" },
                    { 15, 2, new TimeSpan(0, 0, 2, 43, 0), "Porcelain" },
                    { 16, 2, new TimeSpan(0, 0, 4, 0, 0), "Emit Remus" },
                    { 17, 2, new TimeSpan(0, 0, 2, 37, 0), "I Like Dirt" },
                    { 18, 2, new TimeSpan(0, 0, 3, 45, 0), "This Velvet Glove" },
                    { 19, 2, new TimeSpan(0, 0, 4, 52, 0), "Savior" },
                    { 20, 2, new TimeSpan(0, 0, 4, 13, 0), "Purple Stain" },
                    { 21, 2, new TimeSpan(0, 0, 1, 52, 0), "Right on Time" },
                    { 22, 2, new TimeSpan(0, 0, 3, 25, 0), "Road Trippin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandID",
                table: "Albums",
                column: "BandID");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GenreID",
                table: "Albums",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Bands_CountryID",
                table: "Bands",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayLists_CategoryID",
                table: "PlayLists",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TrackPlaylists_PlaylistID",
                table: "TrackPlaylists",
                column: "PlaylistID");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumID",
                table: "Tracks",
                column: "AlbumID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackPlaylists");

            migrationBuilder.DropTable(
                name: "PlayLists");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
