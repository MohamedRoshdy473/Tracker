using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class addassetandmode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDocumentDTO");

            migrationBuilder.DropTable(
                name: "RequestSubCategoryDTO");

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "requests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RequestModeId",
                table: "requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RequestTime",
                table: "requests",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateTable(
                name: "assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(nullable: true),
                    AssetCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "requestModes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestModes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_requests_RequestModeId",
                table: "requests",
                column: "RequestModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requestModes_RequestModeId",
                table: "requests",
                column: "RequestModeId",
                principalTable: "requestModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_requestModes_RequestModeId",
                table: "requests");

            migrationBuilder.DropTable(
                name: "assets");

            migrationBuilder.DropTable(
                name: "requestModes");

            migrationBuilder.DropIndex(
                name: "IX_requests_RequestModeId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "RequestModeId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "RequestTime",
                table: "requests");

            migrationBuilder.CreateTable(
                name: "ProjectDocumentDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDocumentDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestSubCategoryDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestCategoryId = table.Column<int>(type: "int", nullable: false),
                    RequestCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSubCategoryDTO", x => x.Id);
                });
        }
    }
}
