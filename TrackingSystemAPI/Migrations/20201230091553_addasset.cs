using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class addasset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_requests_AssetId",
                table: "requests",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_assets_AssetId",
                table: "requests",
                column: "AssetId",
                principalTable: "assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_assets_AssetId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_AssetId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "requests");
        }
    }
}
