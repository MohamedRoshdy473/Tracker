using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class asset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_projectTypes_ProjectTypeId",
                table: "projects");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectTypeId",
                table: "projects",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_projectTypes_ProjectTypeId",
                table: "projects",
                column: "ProjectTypeId",
                principalTable: "projectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_projectTypes_ProjectTypeId",
                table: "projects");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectTypeId",
                table: "projects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_projectTypes_ProjectTypeId",
                table: "projects",
                column: "ProjectTypeId",
                principalTable: "projectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
