using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class mapmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "lat",
                table: "organizations",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "lng",
                table: "organizations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lat",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "lng",
                table: "organizations");
        }
    }
}
