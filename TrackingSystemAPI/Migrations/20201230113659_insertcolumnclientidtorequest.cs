using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class insertcolumnclientidtorequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_requests_ClientId",
                table: "requests",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_clients_ClientId",
                table: "requests",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_clients_ClientId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_ClientId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "requests");
        }
    }
}
