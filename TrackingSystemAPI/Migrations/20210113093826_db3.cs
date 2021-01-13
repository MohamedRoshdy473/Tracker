using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class db3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestProblemsDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemId = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    ProblemName = table.Column<string>(nullable: true),
                    RequestName = table.Column<string>(nullable: true),
                    RequestCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    RequestTime = table.Column<string>(nullable: true),
                    IsSolved = table.Column<bool>(nullable: true),
                    IsAssigned = table.Column<bool>(nullable: true),
                    RequestSubCategoryId = table.Column<int>(nullable: false),
                    RequestSubCategoryName = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    ClientName = table.Column<string>(nullable: true),
                    ProjectTeamId = table.Column<int>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    TeamName = table.Column<string>(nullable: true),
                    RequestModeId = table.Column<int>(nullable: false),
                    RequestMode = table.Column<string>(nullable: true),
                    AssetId = table.Column<int>(nullable: false),
                    AssetCode = table.Column<string>(nullable: true),
                    RequestStatusId = table.Column<int>(nullable: false),
                    RequestStatus = table.Column<string>(nullable: true),
                    RequestPeriorityId = table.Column<int>(nullable: false),
                    RequestPeriority = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestProblemsDTO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestProblemsDTO");
        }
    }
}
