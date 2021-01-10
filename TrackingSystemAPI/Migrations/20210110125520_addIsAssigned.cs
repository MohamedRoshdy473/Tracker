using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class addIsAssigned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAssigned",
                table: "requests",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSolved",
                table: "requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAssigned",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "IsSolved",
                table: "requests");
        }
    }
}
