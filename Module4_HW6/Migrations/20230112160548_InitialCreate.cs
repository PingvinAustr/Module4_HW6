using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Module4HW6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SongDuration = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistsSongs",
                columns: table => new
                {
                    ArtistsSongsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistsSongs", x => x.ArtistsSongsId);
                    table.ForeignKey(
                        name: "FK_ArtistsSongs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistsSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "ArtistName", "DateOfBirth", "Email", "InstagramUrl", "Phone" },
                values: new object[,]
                {
                    { 1, "Rammstein", new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "https://www.instagram.com/rammsteinofficial/", "380632140021" },
                    { 2, "Eminem", new DateTime(1972, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "https://www.instagram.com/eminem/", "" },
                    { 3, "Maroon 5", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "https://www.instagram.com/maroon5/", "" },
                    { 4, "Alan Walker", new DateTime(1997, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "https://www.instagram.com/alanwalkermusic/", "" },
                    { 5, "Ukraine", new DateTime(2023, 1, 12, 18, 5, 48, 442, DateTimeKind.Local).AddTicks(8810), "", "", "" },
                    { 6, "ReSinger", new DateTime(2023, 1, 12, 18, 5, 48, 442, DateTimeKind.Local).AddTicks(8842), "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Pop" },
                    { 3, "Folk" },
                    { 4, "Rap" },
                    { 5, "Electro" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "GenreId", "ReleaseDate", "SongDuration", "SongTitle" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2013, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 363, "Rap god" },
                    { 2, 1, new DateTime(2019, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 323, "Deutschland" },
                    { 3, 3, new DateTime(1914, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 195, "Oy U Luzi Chervona Kalyna" },
                    { 4, 2, new DateTime(2011, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, "Moves like Jagger" },
                    { 5, 5, new DateTime(2016, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 162, "Alone" }
                });

            migrationBuilder.InsertData(
                table: "ArtistsSongs",
                columns: new[] { "ArtistsSongsId", "ArtistId", "SongId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 1, 2 },
                    { 3, 5, 3 },
                    { 4, 3, 4 },
                    { 5, 4, 5 },
                    { 6, 6, 1 },
                    { 7, 6, 2 },
                    { 8, 6, 3 },
                    { 9, 6, 4 },
                    { 10, 6, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsSongs_ArtistId",
                table: "ArtistsSongs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistsSongs_SongId",
                table: "ArtistsSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistsSongs");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
