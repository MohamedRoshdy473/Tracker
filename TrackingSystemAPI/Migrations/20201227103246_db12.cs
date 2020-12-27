using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class db12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentFile",
                table: "ProjectDocumentDTO",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "ProjectDocumentDTO",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentFile",
                table: "ProjectDocumentDTO");

            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "ProjectDocumentDTO");
        }
    }
}
