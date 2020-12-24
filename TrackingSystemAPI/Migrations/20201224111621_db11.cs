using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class db11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentFile",
                table: "projectDocuments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "projectDocuments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentFile",
                table: "projectDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "projectDocuments");
        }
    }
}
