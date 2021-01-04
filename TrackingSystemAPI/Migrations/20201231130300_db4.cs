using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class db4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "requestDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_requestDescriptions_requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requestDescriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_requestDescriptions_RequestId",
                table: "requestDescriptions",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_requestDescriptions_UserId",
                table: "requestDescriptions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requestDescriptions");
        }
    }
}
