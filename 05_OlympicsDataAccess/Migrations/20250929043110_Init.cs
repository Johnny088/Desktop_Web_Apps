using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _05_OlympicsDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryHosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryHosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<int>(type: "int", nullable: false),
                    TypeOfMedal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NameOfGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameOfGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountyTeamID = table.Column<int>(type: "int", nullable: false),
                    NameOfGameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_CountryTeams_CountyTeamID",
                        column: x => x.CountyTeamID,
                        principalTable: "CountryTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_NameOfGames_NameOfGameID",
                        column: x => x.NameOfGameID,
                        principalTable: "NameOfGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Olympics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountyHostID = table.Column<int>(type: "int", nullable: false),
                    SeasonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olympics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Olympics_CountryHosts_CountyHostID",
                        column: x => x.CountyHostID,
                        principalTable: "CountryHosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Olympics_Seasons_SeasonID",
                        column: x => x.SeasonID,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedalID = table.Column<int>(type: "int", nullable: false),
                    OlympicID = table.Column<int>(type: "int", nullable: false),
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Awards_Medals_MedalID",
                        column: x => x.MedalID,
                        principalTable: "Medals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Awards_Olympics_OlympicID",
                        column: x => x.OlympicID,
                        principalTable: "Olympics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Awards_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CountryHosts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "France" },
                    { 2, "Japan" },
                    { 3, "Canada" },
                    { 4, "The USA" },
                    { 5, "England" }
                });

            migrationBuilder.InsertData(
                table: "CountryTeams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "The USA" },
                    { 2, "France" },
                    { 3, "Japan" },
                    { 4, "England" },
                    { 5, "Canada" }
                });

            migrationBuilder.InsertData(
                table: "Medals",
                columns: new[] { "Id", "Place", "TypeOfMedal" },
                values: new object[,]
                {
                    { 1, 0, "Gold" },
                    { 2, 0, "Silver" },
                    { 3, 0, "Bronze" }
                });

            migrationBuilder.InsertData(
                table: "NameOfGames",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Surfing" },
                    { 2, "Skateboarding" },
                    { 3, "BMX Freestyle" },
                    { 4, "Snowboarding" },
                    { 5, "Snowboarding Halfpipe" }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Summer" },
                    { 2, "Winter" }
                });

            migrationBuilder.InsertData(
                table: "Olympics",
                columns: new[] { "Id", "CountyHostID", "EndDate", "SeasonID", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2010, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2010, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2002, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2002, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2012, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2012, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CountyTeamID", "Name", "NameOfGameID", "Surname" },
                values: new object[,]
                {
                    { 1, 2, "Kauli", 1, "Vaast" },
                    { 2, 1, "Caroline", 1, "Marks" },
                    { 3, 2, "Johanne", 1, "Defay" },
                    { 4, 3, "Yuto", 2, "Horigome" },
                    { 5, 1, "Jagger", 2, "Eaton" },
                    { 6, 1, "Nyjah", 2, "Huston" },
                    { 7, 3, "Cocona", 2, "Hiraki" },
                    { 8, 4, "Sky", 2, "Brown" },
                    { 9, 4, "Kieran", 3, "Reilly" },
                    { 10, 2, "Anthony", 3, "Jeanjean" },
                    { 11, 1, "Perris", 3, "Benegas" },
                    { 12, 3, "Kanoa", 1, "Igarashi" },
                    { 13, 1, "Carissa", 1, "Moore" },
                    { 14, 3, "Amuro", 1, "Tsuzuki" },
                    { 15, 3, "Sakura", 2, "Yosozumi" },
                    { 16, 4, "Declan", 3, "Brooks" },
                    { 17, 4, "Charlotte", 3, "Worthington" },
                    { 18, 1, "Hannah", 3, "Roberts" },
                    { 19, 1, "Seth", 4, "Wescott" },
                    { 20, 5, "Mike", 4, "Robertson" },
                    { 21, 2, "Tony", 4, "Ramoin" },
                    { 22, 1, "Shaun", 5, "White" },
                    { 23, 1, "Scott", 5, "Lago" },
                    { 24, 1, "Hannah", 5, "Teter" },
                    { 25, 1, "Kelly", 5, "Clark" },
                    { 26, 1, "Ross", 5, "Powers" },
                    { 27, 1, "Danny", 5, "Kass" },
                    { 28, 1, "Jarret (J.J.)", 5, "Thomas" },
                    { 29, 2, "Doriane", 5, "Vidal" }
                });

            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "MedalID", "OlympicID", "PlayerID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 1, 2 },
                    { 3, 3, 1, 3 },
                    { 4, 1, 1, 4 },
                    { 5, 2, 1, 5 },
                    { 6, 3, 1, 6 },
                    { 7, 2, 1, 7 },
                    { 8, 3, 1, 8 },
                    { 9, 2, 1, 9 },
                    { 10, 3, 1, 10 },
                    { 11, 2, 1, 11 },
                    { 12, 1, 2, 4 },
                    { 13, 3, 2, 5 },
                    { 14, 2, 2, 7 },
                    { 15, 3, 2, 8 },
                    { 16, 2, 2, 12 },
                    { 17, 1, 2, 13 },
                    { 18, 3, 2, 14 },
                    { 19, 1, 2, 15 },
                    { 20, 3, 2, 16 },
                    { 21, 1, 2, 17 },
                    { 22, 2, 2, 18 },
                    { 23, 1, 3, 19 },
                    { 24, 3, 2, 20 },
                    { 25, 3, 3, 21 },
                    { 26, 1, 3, 22 },
                    { 27, 3, 3, 23 },
                    { 28, 2, 3, 24 },
                    { 29, 3, 3, 25 },
                    { 30, 1, 4, 25 },
                    { 31, 1, 4, 26 },
                    { 32, 2, 4, 27 },
                    { 33, 3, 4, 28 },
                    { 34, 2, 4, 29 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Awards_MedalID",
                table: "Awards",
                column: "MedalID");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_OlympicID",
                table: "Awards",
                column: "OlympicID");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_PlayerID",
                table: "Awards",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Olympics_CountyHostID",
                table: "Olympics",
                column: "CountyHostID");

            migrationBuilder.CreateIndex(
                name: "IX_Olympics_SeasonID",
                table: "Olympics",
                column: "SeasonID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CountyTeamID",
                table: "Players",
                column: "CountyTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_NameOfGameID",
                table: "Players",
                column: "NameOfGameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Medals");

            migrationBuilder.DropTable(
                name: "Olympics");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "CountryHosts");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "CountryTeams");

            migrationBuilder.DropTable(
                name: "NameOfGames");
        }
    }
}
