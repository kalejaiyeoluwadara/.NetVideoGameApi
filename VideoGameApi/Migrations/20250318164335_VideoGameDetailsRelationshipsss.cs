using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameApi.Migrations
{
    /// <inheritdoc />
    public partial class VideoGameDetailsRelationshipsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VideoGameDetails_VideoGameId",
                table: "VideoGameDetails",
                column: "VideoGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGameDetails_VideoGames_VideoGameId",
                table: "VideoGameDetails",
                column: "VideoGameId",
                principalTable: "VideoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGameDetails_VideoGames_VideoGameId",
                table: "VideoGameDetails");

            migrationBuilder.DropIndex(
                name: "IX_VideoGameDetails_VideoGameId",
                table: "VideoGameDetails");
        }
    }
}
