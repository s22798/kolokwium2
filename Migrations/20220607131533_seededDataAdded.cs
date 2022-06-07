using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium2.Migrations
{
    public partial class seededDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicianTracks_Tracks_IdTrack",
                table: "MusicianTracks");

            migrationBuilder.InsertData(
                table: "MusicLabels",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[] { 1, "Capalot" });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "IdMusician", "FirstName", "LastName", "NickName" },
                values: new object[] { 1, "Taurus", "Bartlett", "Polo G" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[] { 1, "Hall of fame", 1, new DateTime(2020, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 1, 3f, 1, "33" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 2, 3f, 1, "21" });

            migrationBuilder.InsertData(
                table: "MusicianTracks",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[] { 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianTracks_Tracks_IdTrack",
                table: "MusicianTracks",
                column: "IdTrack",
                principalTable: "Tracks",
                principalColumn: "IdTrack",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicianTracks_Tracks_IdTrack",
                table: "MusicianTracks");

            migrationBuilder.DeleteData(
                table: "MusicianTracks",
                keyColumns: new[] { "IdMusician", "IdTrack" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Musicians",
                keyColumn: "IdMusician",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "IdAlbum",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MusicLabels",
                keyColumn: "IdMusicLabel",
                keyValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianTracks_Tracks_IdTrack",
                table: "MusicianTracks",
                column: "IdTrack",
                principalTable: "Tracks",
                principalColumn: "IdTrack",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
