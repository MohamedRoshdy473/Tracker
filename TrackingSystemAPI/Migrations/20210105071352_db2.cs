using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "lat",
                table: "organizations",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "lng",
                table: "organizations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "assignedRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectPositionId = table.Column<int>(nullable: false),
                    ProjectTeamId = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignedRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_assignedRequests_projectPositions_ProjectPositionId",
                        column: x => x.ProjectPositionId,
                        principalTable: "projectPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assignedRequests_projectTeams_ProjectTeamId",
                        column: x => x.ProjectTeamId,
                        principalTable: "projectTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assignedRequests_requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignedRequests_ProjectPositionId",
                table: "assignedRequests",
                column: "ProjectPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_assignedRequests_ProjectTeamId",
                table: "assignedRequests",
                column: "ProjectTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_assignedRequests_RequestId",
                table: "assignedRequests",
                column: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignedRequests");

            migrationBuilder.DropColumn(
                name: "lat",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "lng",
                table: "organizations");
        }
    }
}
