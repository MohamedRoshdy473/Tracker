using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class addcolumnProjectTeamIdinRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_projects_ProjectId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_requestTypes_RequestTypeId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_ProjectId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_RequestTypeId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "RequestTypeId",
                table: "requests");

            migrationBuilder.AddColumn<int>(
                name: "ProjectTeamId",
                table: "requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_requests_ProjectTeamId",
                table: "requests",
                column: "ProjectTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_projectTeams_ProjectTeamId",
                table: "requests",
                column: "ProjectTeamId",
                principalTable: "projectTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_projectTeams_ProjectTeamId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_ProjectTeamId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "ProjectTeamId",
                table: "requests");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestTypeId",
                table: "requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_requests_ProjectId",
                table: "requests",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_RequestTypeId",
                table: "requests",
                column: "RequestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_projects_ProjectId",
                table: "requests",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requestTypes_RequestTypeId",
                table: "requests",
                column: "RequestTypeId",
                principalTable: "requestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
