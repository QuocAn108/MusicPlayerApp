using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecentSongs_Songs_SongId",
                table: "RecentSongs");

            migrationBuilder.DropIndex(
                name: "IX_RecentSongs_SongId",
                table: "RecentSongs");

            migrationBuilder.AddColumn<int>(
                name: "SongsSongId",
                table: "RecentSongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecentSongs_SongsSongId",
                table: "RecentSongs",
                column: "SongsSongId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecentSongs_Songs_SongsSongId",
                table: "RecentSongs",
                column: "SongsSongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
