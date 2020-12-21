using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class db6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "requestTypes");

            migrationBuilder.AddColumn<string>(
                name: "RequestTypeName",
                table: "requestTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestTypeName",
                table: "requestTypes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "requestTypes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
