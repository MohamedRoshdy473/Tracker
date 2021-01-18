using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class addimageinclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "clients");
        }
    }
}
