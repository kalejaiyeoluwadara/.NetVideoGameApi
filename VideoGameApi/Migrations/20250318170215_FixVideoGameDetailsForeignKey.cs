using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameApi.Migrations
{
    /// <inheritdoc />
    public partial class FixVideoGameDetailsForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideoGameId1",
                table: "VideoGameDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoGameDetails_VideoGameId1",
                table: "VideoGameDetails",
                column: "VideoGameId1",
                unique: true,
                filter: "[VideoGameId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGameDetails_VideoGames_VideoGameId1",
                table: "VideoGameDetails",
                column: "VideoGameId1",
                principalTable: "VideoGames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGameDetails_VideoGames_VideoGameId1",
                table: "VideoGameDetails");

            migrationBuilder.DropIndex(
                name: "IX_VideoGameDetails_VideoGameId1",
                table: "VideoGameDetails");

            migrationBuilder.DropColumn(
                name: "VideoGameId1",
                table: "VideoGameDetails");
        }
    }
}
