using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicList.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    MusicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.MusicId);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Songs_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "MusicId");
                });

            migrationBuilder.InsertData(
                table: "Music",
                columns: new[] { "MusicId", "Artist", "Rating", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Artist 1", 4, "Song Title 1", 2000 },
                    { 2, "Artist 2", 5, "Song Title 2", 2010 }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "Duration", "MusicId", "Title" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 3, 30, 0), null, "Song Title 1" },
                    { 2, new TimeSpan(0, 0, 4, 15, 0), null, "Song Title 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_MusicId",
                table: "Songs",
                column: "MusicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Music");
        }
    }
}
